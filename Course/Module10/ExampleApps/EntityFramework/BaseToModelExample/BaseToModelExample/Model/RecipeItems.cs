//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseToModelExample.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecipeItems
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int Amount { get; set; }
        public int Measure { get; set; }
        public int RecipeId { get; set; }
    
        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}