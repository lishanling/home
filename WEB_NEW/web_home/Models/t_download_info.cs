namespace web_home.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("t_download_info")]
    public partial class t_download_info
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(100)]
        public string version { get; set; }

        public int? type { get; set; }

        public int? type2 { get; set; }
        public int? status { get; set; }

        [StringLength(500)]
        public string url { get; set; }

        public int? platform { get; set; }

        public DateTime updateTime { get; set; }
    }
}
