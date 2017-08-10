namespace MeLo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExtensionSet")]
    public partial class ExtensionSet
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int TypeId { get; set; }

        public virtual TypeSet TypeSet { get; set; }
    }
}
