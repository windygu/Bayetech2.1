﻿/*******************************************************************************
 * Copyright © 2017 平台组 版权所有
 * Author: Zhaoyz
 * Description: 快速开发平台
*********************************************************************************/

using Bayetech.Core;
using Bayetech.Core.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;


namespace Bayetech.DAL
{
    /// <summary>
    /// 仓储实现
    /// </summary>
    public class RepositoryBase : IRepositoryBase, IDisposable
    {
        private DbTransaction dbTransaction { get; set; }
        public DbContext dbcontext = null;

        public RepositoryBase(DbContext db = null)
        {
            dbcontext = (db == null ? DBFactory.Bayetech : db);
        }

        public IRepositoryBase BeginTrans()
        {
            DbConnection dbConnection = ((IObjectContextAdapter)dbcontext).ObjectContext.Connection;
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            dbTransaction = dbConnection.BeginTransaction();
            return this;
        }
        public int Commit()
        {
            try
            {
                var returnValue = dbcontext.SaveChanges();
                if (dbTransaction != null)
                {
                    dbTransaction.Commit();
                }
                return returnValue;
            }
            catch (DbEntityValidationException ex)
            { 
                if (dbTransaction != null)
                {
                    this.dbTransaction.Rollback();
                }
                throw new Exception(Common.ExceptionForWriteEntity(ex)); ;
            }
            finally
            {
                this.Dispose();
            }
        }
        public void Dispose()
        {
            if (dbTransaction != null)
            {
                this.dbTransaction.Dispose();
            }
            this.dbcontext.Dispose();
        }
        public int Insert<TEntity>(TEntity entity) where TEntity : class
        {
            dbcontext.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Added;
            return dbTransaction == null ? this.Commit() : 0;
        }
        public int Insert<TEntity>(List<TEntity> entitys) where TEntity : class
        {
            foreach (var entity in entitys)
            {
                dbcontext.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Added;
            }
            return dbTransaction == null ? this.Commit() : 0;
        }
        public int Update<TEntity>(TEntity entity) where TEntity : class
        {
            dbcontext.Set<TEntity>().Attach(entity);
            PropertyInfo[] props = entity.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(entity, null) != null)
                {
                    if (prop.GetValue(entity, null).ToString() == "&nbsp;")
                        dbcontext.Entry(entity).Property(prop.Name).CurrentValue = null;
                    dbcontext.Entry(entity).Property(prop.Name).IsModified = true;
                }
            }
            return dbTransaction == null ? this.Commit() : 0;
        }
        public int Delete<TEntity>(TEntity entity) where TEntity : class
        {
            dbcontext.Set<TEntity>().Attach(entity);
            dbcontext.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Deleted;
            return dbTransaction == null ? 1: 0;
        }
        public int Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var entitys = dbcontext.Set<TEntity>().Where(predicate).ToList();
            entitys.ForEach(m => dbcontext.Entry<TEntity>(m).State = System.Data.Entity.EntityState.Deleted);
            return dbTransaction == null ? this.Commit() : 0;
        }
        public TEntity FindEntity<TEntity>(object keyValue) where TEntity : class
        {
            return dbcontext.Set<TEntity>().Find(keyValue);
        }
        public TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return dbcontext.Set<TEntity>().FirstOrDefault(predicate);
        }
        public IQueryable<TEntity> IQueryable<TEntity>() where TEntity : class
        {
            return dbcontext.Set<TEntity>();
        }
        public IQueryable<TEntity> IQueryable<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return dbcontext.Set<TEntity>().Where(predicate);
        }
        public List<TEntity> FindList<TEntity>(string strSql) where TEntity : class
        {
            return dbcontext.Database.SqlQuery<TEntity>(strSql).ToList<TEntity>();
        }
        public List<TEntity> FindList<TEntity>(string strSql, DbParameter[] dbParameter) where TEntity : class
        {

            return dbcontext.Database.SqlQuery<TEntity>(strSql, dbParameter).ToList<TEntity>();
        }
        
        /// <summary>
        /// 分页查找，返回List
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public List<TEntity> FindList<TEntity>(Pagination pagination,Expression<Func<TEntity, bool>> predicate = null) where TEntity : class,new()
        {
            if (pagination != null)
            {
                bool isAsc = pagination.sord.ToLower() == "asc" ? true : false;
                string[] _order = pagination.order.Split(',');
                MethodCallExpression resultExp = null;
                var tempData = predicate == null ? dbcontext.Set<TEntity>().AsQueryable()
                     : dbcontext.Set<TEntity>().Where(predicate.Compile()).AsQueryable();
                foreach (string item in _order)
                {
                    string _orderPart = item;
                    _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
                    string[] _orderArry = _orderPart.Split(' ');
                    string _orderField = _orderArry[0];
                    bool sort = isAsc;
                    if (_orderArry.Length == 2)
                    {
                        isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
                    }
                    var parameter = Expression.Parameter(typeof(TEntity), "t");
                    var property = typeof(TEntity).GetProperty(_orderField);
                    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                    var orderByExp = Expression.Lambda(propertyAccess, parameter);
                    resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(TEntity), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
                }
                tempData = tempData.Provider.CreateQuery<TEntity>(resultExp).AsQueryable();
                pagination.records = tempData.Count();
                tempData = tempData.Skip<TEntity>(pagination.rows * (pagination.page - 1)).Take<TEntity>(pagination.rows).AsQueryable();
                return tempData.ToList();
            }
            else
            {
                return dbcontext.Set<TEntity>().Where(predicate.Compile()).AsQueryable().ToList();
            }
        }

        /// <summary>
        /// 需要返回分页的FindList.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="pagination"></param>
        /// <param name="NewPage"></param>
        /// <returns></returns>
        public List<TEntity> FindList<TEntity>(Pagination pagination, out Pagination NewPage,Expression<Func<TEntity, bool>> predicate = null) where TEntity : class, new()
        {
            if (pagination != null)
            {
                bool isAsc = pagination.sord.ToLower() == "asc" ? true :  false;
                string[] _order = pagination.order.Split(',');
                MethodCallExpression resultExp = null;
                var tempData = dbcontext.Set<TEntity>().Where(predicate.Compile()).AsQueryable();
                //var tempData = dbcontext.Set<TEntity>().AsQueryable();
                foreach (string item in _order)
                {
                    string _orderPart = item;
                    _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
                    string[] _orderArry = _orderPart.Split(' ');
                    string _orderField = _orderArry[0];
                    bool sort = isAsc;
                    if (_orderArry.Length == 2)
                    {
                        isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
                    }
                    var parameter = Expression.Parameter(typeof(TEntity), "t");
                    var property = typeof(TEntity).GetProperty(_orderField);
                    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                    var orderByExp = Expression.Lambda(propertyAccess, parameter);
                    resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(TEntity), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
                }
                tempData = tempData.Provider.CreateQuery<TEntity>(resultExp);
                pagination.records = tempData.Count();
                tempData = tempData.Skip<TEntity>(pagination.rows * (pagination.page - 1)).Take<TEntity>(pagination.rows).AsQueryable();
                NewPage = pagination;
                return tempData.ToList();
            }
            else
            {
                NewPage = pagination;
                return dbcontext.Set<TEntity>().Where(predicate.Compile()).AsQueryable().ToList();
            }
        }

        /// <summary>
        /// 查询集合带分页对象（最常用，page=null为不分页）
        /// </summary>
        /// <param name="page">分页对象</param>
         /// <param name="predicate">lamad表达式</param>
        /// <returns></returns>
        public JObject GetList<TEntity>(Expression<Func<TEntity, bool>> predicate=null, Pagination page = null) where TEntity : class, new()
        {
            var jObect = new JObject();
            var result = FindList(page, out page, predicate);
            return Common.PackageJObect(result.Count > 0, result, page);
        }

        public bool BulkInsert<TEntity>(List<TEntity> list) where TEntity : class
        {
            try
            {
                dbcontext.BulkInsert(list);
                dbcontext.BulkSaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
