namespace web_home.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("t_user")]
    public partial class t_user
    {
        [Key]
        public int uid { get; set; }

        [StringLength(50)]
        public string uaccount { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        public int? state { get; set; }

        public int? roleId { get; set; }
         [StringLength(50)]
        public string token { get; set; }
    }
}
