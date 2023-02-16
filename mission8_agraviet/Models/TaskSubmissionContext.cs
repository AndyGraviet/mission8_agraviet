using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace mission8_agraviet.Models
{
	public class TaskSubmissionContext : DbContext
	{
		public TaskSubmissionContext(DbContextOptions<TaskSubmissionContext> options) : base (options)
		{
		}

		public DbSet<Task> responses { get; set; }
		public DbSet<Category> categories { get; set; }
		public DbSet<Quadrant> quadrants { get; set; }

		protected override void OnModelCreating(ModelBuilder mb)
		{
			mb.Entity<Category>().HasData(
				new Category { CategoryId = 1, CategoryName = "Home" },
				new Category { CategoryId = 2, CategoryName = "School" },
				new Category { CategoryId = 3, CategoryName = "Work" },
				new Category { CategoryId = 4, CategoryName = "church" }
			);

			mb.Entity<Quadrant>().HasData(
				new Quadrant { QuadrantId = 1, QuadrantName = "Urgent, Important"},
                new Quadrant { QuadrantId = 2, QuadrantName = "Not Urgent, Important" },
                new Quadrant { QuadrantId = 3, QuadrantName = "Urgent, Not Important" },
                new Quadrant { QuadrantId = 4, QuadrantName = "Not Urgent, Not Important" }
            );

			mb.Entity<Task>().HasData(
				new Task
				{
					TaskId = 1,
					CategoryId = 1,
					TaskTitle = "Test Task 1",
					TaskNotes = "These are notes for 1",
					DueDate = new DateTime(2022, 3, 15),
					QuadrantId = 1,
					Completed = false
				},
                new Task
                {
                    TaskId = 2,
                    CategoryId = 2,
                    TaskTitle = "Test Task 2",
                    TaskNotes = "These are notes for 2",
                    DueDate = new DateTime(2022, 3, 15),
                    QuadrantId = 2,
                    Completed = false
                },
                new Task
                {
                    TaskId = 3,
                    CategoryId = 3,
                    TaskTitle = "Test Task 3",
                    TaskNotes = "These are notes for 3",
                    DueDate = new DateTime(2022, 3, 15),
                    QuadrantId = 3,
                    Completed = true
                }

            );
		}
	}
}

