//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webtest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class note
    {
        public int id { get; set; }
        public int customerid { get; set; }
        public string createdbyuser { get; set; }
        public string body { get; set; }
    
        public virtual customer customer { get; set; }
    }
}
