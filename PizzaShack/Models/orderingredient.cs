//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzaShack.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class orderingredient
    {
        public int orderid { get; set; }
        public int ingredientid { get; set; }
        public int quantity { get; set; }
    
        public virtual ingredient ingredient { get; set; }
        public virtual order order { get; set; }
    }
}
