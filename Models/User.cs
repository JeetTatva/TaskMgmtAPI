using System;
using System.ComponentModel.DataAnnotations;

namespace TaskMgmtApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt  { get; set; }
    }
}