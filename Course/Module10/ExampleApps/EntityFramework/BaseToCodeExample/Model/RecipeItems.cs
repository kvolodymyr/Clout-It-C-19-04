namespace BaseToCodeExample.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
