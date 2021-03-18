using System;
using System.ComponentModel.DataAnnotations;

namespace WIS.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Nickname { get; set; }
        [Required] public string HashPassword { get; set; }

        [Required] public string Salt { get; set; }
        [DataType(DataType.DateTime)] public DateTime CreatedAt { get; set; }
    }
}