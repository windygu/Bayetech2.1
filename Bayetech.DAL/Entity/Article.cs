
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------


namespace Bayetech.DAL.Entity
{

using System;
    using System.Collections.Generic;
    
public partial class Article
{

    public long itemid { get; set; }

    public int catid { get; set; }

    public int areaid { get; set; }

    public byte level { get; set; }

    public string title { get; set; }

    public string style { get; set; }

    public float fee { get; set; }

    public string subtitle { get; set; }

    public string introduce { get; set; }

    public string tag { get; set; }

    public string keyword { get; set; }

    public string pptword { get; set; }

    public string author { get; set; }

    public string copyfrom { get; set; }

    public string fromurl { get; set; }

    public string voteid { get; set; }

    public int hits { get; set; }

    public string thumb { get; set; }

    public string username { get; set; }

    public int addtime { get; set; }

    public string editor { get; set; }

    public int edittime { get; set; }

    public string ip { get; set; }

    public string template { get; set; }

    public byte status { get; set; }

    public byte islink { get; set; }

    public string linkurl { get; set; }

    public string filepath { get; set; }

    public string note { get; set; }



    public virtual ArticleContent ArticleContent { get; set; }

}

}
