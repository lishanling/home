namespace web_home.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("classmate")]
    public partial class classmate
    {
        [Key]
        public int cid { get; set; }

        [StringLength(200)]
        public string cname { get; set; }

        public int? cnumber { get; set; }

        [StringLength(50)]
        public string cteacher { get; set; }
    }
}
