namespace BaseToCodeExample.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table
    {
        public int Id { get; set; }

        public int PizzaId { get; set; }

        public DateTime OrderedAt { get; set; }

        public virtual Pizza Pizza { get; set; }
    }
}
