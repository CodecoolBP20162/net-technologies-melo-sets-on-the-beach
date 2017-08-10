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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MediaSet()
        {
            PlaylistSet = new HashSet<PlaylistSet>();
        }

        public int Id { get; set; }

        [Required]
        public string Path { get; set; }

        public int TypeId { get; set; }

        public virtual TypeSet TypeSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaylistSet> PlaylistSet { get; set; }
    }
}
