using System;
using System.ComponentModel.DataAnnotations;

namespace mission8_agraviet.Models
{
	public class Quadrant
	{
        [Key]
        [Required]
        public int QuadrantId { get; set; }
        public string QuadrantName { get; set; }
    }
}

