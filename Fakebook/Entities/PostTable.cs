namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostTable")]
    public partial class PostTable
    {
        public int ID { get; set; }

        public int SenderID { get; set; }

        [Required]
        [StringLength(50)]
        public string PostTitle { get; set; }

        [Required]
        public string Detail { get; set; }
    }
}
