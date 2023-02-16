using System;
using System.ComponentModel.DataAnnotations;


namespace mission8_agraviet.Models
{
	public class Task
	{
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public int QuadrantId { get; set; }

        public Quadrant Quadrant { get; set; }
        
        [Required]
        public string TaskTitle { get; set; }

        public string TaskNotes { get; set; }

        [Required]
        public DateTime DueDate { get; set; }



        public bool Completed { get; set; }
        
    }
}

