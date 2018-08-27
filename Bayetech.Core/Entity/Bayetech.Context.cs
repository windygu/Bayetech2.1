﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bayetech.Core.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BayetechEntities : DbContext
    {
        public BayetechEntities()
            : base("name=BayetechEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Admin_C1_Customer> Admin_C1_Customer { get; set; }
        public virtual DbSet<Admin_Sys_Area> Admin_Sys_Area { get; set; }
        public virtual DbSet<Admin_Sys_Area_bac> Admin_Sys_Area_bac { get; set; }
        public virtual DbSet<Admin_Sys_Buttons> Admin_Sys_Buttons { get; set; }
        public virtual DbSet<Admin_Sys_Config> Admin_Sys_Config { get; set; }
        public virtual DbSet<Admin_Sys_Departments> Admin_Sys_Departments { get; set; }
        public virtual DbSet<Admin_Sys_DicCategory> Admin_Sys_DicCategory { get; set; }
        public virtual DbSet<Admin_Sys_Dics> Admin_Sys_Dics { get; set; }
        public virtual DbSet<Admin_Sys_LogDetails> Admin_Sys_LogDetails { get; set; }
        public virtual DbSet<Admin_Sys_logs> Admin_Sys_logs { get; set; }
        public virtual DbSet<Admin_Sys_NavButtons> Admin_Sys_NavButtons { get; set; }
        public virtual DbSet<Admin_Sys_RoleNavBtns> Admin_Sys_RoleNavBtns { get; set; }
        public virtual DbSet<Admin_Sys_Roles> Admin_Sys_Roles { get; set; }
        public virtual DbSet<Admin_Sys_Roles_Departments> Admin_Sys_Roles_Departments { get; set; }
        public virtual DbSet<Admin_Sys_UserNavBtns> Admin_Sys_UserNavBtns { get; set; }
        public virtual DbSet<Admin_Sys_UserRoles> Admin_Sys_UserRoles { get; set; }
        public virtual DbSet<Admin_Sys_Users> Admin_Sys_Users { get; set; }
        public virtual DbSet<Admin_Sys_Users_Departments> Admin_Sys_Users_Departments { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleContent> ArticleContent { get; set; }
        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<DLRequire> DLRequire { get; set; }
        public virtual DbSet<ExtraProperty> ExtraProperty { get; set; }
        public virtual DbSet<ExtraPropertyValue> ExtraPropertyValue { get; set; }
        public virtual DbSet<GameAccount> GameAccount { get; set; }
        public virtual DbSet<GameInfoDescription> GameInfoDescription { get; set; }
        public virtual DbSet<GameProfession> GameProfession { get; set; }
        public virtual DbSet<GoodStatus> GoodStatus { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<MallDLInfo> MallDLInfo { get; set; }
        public virtual DbSet<MallType> MallType { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Relationship> Relationship { get; set; }
        public virtual DbSet<Server> Server { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<GoodAndDescription> GoodAndDescription { get; set; }
        public virtual DbSet<MallGoodPictures> MallGoodPictures { get; set; }
        public virtual DbSet<vw_ArticleModule> vw_ArticleModule { get; set; }
        public virtual DbSet<vw_GameServers> vw_GameServers { get; set; }
        public virtual DbSet<vw_GoodTypes> vw_GoodTypes { get; set; }
        public virtual DbSet<vw_LoginInfo> vw_LoginInfo { get; set; }
        public virtual DbSet<vw_MallDLInfo> vw_MallDLInfo { get; set; }
        public virtual DbSet<vw_MallDLOrderInfo> vw_MallDLOrderInfo { get; set; }
        public virtual DbSet<vw_MallPictureInfo> vw_MallPictureInfo { get; set; }
        public virtual DbSet<vw_NoToProperty> vw_NoToProperty { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<MallGoodInfo> MallGoodInfo { get; set; }
        public virtual DbSet<vw_MallGoodInfo> vw_MallGoodInfo { get; set; }
        public virtual DbSet<vw_MallGoodSearch> vw_MallGoodSearch { get; set; }
        public virtual DbSet<vw_MallGoodMainInfo> vw_MallGoodMainInfo { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<MallOrder> MallOrder { get; set; }
        public virtual DbSet<vw_MallOrderInfo> vw_MallOrderInfo { get; set; }
        public virtual DbSet<Admin_Sys_Login> Admin_Sys_Login { get; set; }
        public virtual DbSet<Admin_Sys_Navigations> Admin_Sys_Navigations { get; set; }
        public virtual DbSet<Game> Game { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
