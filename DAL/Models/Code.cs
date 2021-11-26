﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Code
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("value")]
        [StringLength(3)]
        public string Value { get; set; }

        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
