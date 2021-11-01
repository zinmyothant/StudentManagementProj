namespace StudentManagementProj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("registration")]
    public partial class registration
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(50)]
        public string lastName { get; set; }

        [StringLength(50)]
        public string NRC { get; set; }

        public int? course_id { get; set; }

        public int? batch_id { get; set; }

        public int? tel { get; set; }

        public virtual batch batch { get; set; }

        public virtual course course { get; set; }
    }
}
