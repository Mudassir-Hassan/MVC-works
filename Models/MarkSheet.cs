//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolDatabase.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MarkSheet
    {
        public int Roll_No { get; set; }
        public string Name { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Math { get; set; }
        public int Total_Marks { get; set; }
    
        public virtual Studentdb Studentdb { get; set; }
    }
}
