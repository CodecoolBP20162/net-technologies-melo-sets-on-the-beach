namespace MeLo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MediaSet")]
    public partial class MediaSet
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public int TypeId { get; set; }

        public int? PlaylistSetId { get; set; }

        public string Name { get; set; }

        public virtual PlaylistSet PlaylistSet { get; set; }

        public virtual TypeSet TypeSet { get; set; }
    }
}
