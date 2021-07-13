using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_home.Models
{
     [Table("Study")]
    public class Study
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("ID")]
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

    }
}