using System;
using System.ComponentModel.DataAnnotations;

namespace TaskMgmtApi.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public User? AssignedToUserId { get; set; }
        public required User CreatedByUserId { get; set; }
        public required string Status { get; set; }
        public required string Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt  { get; set; }
    }
}