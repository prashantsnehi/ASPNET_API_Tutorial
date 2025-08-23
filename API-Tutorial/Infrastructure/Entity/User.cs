using System;
using System.ComponentModel.DataAnnotations;
using API_Tutorial.Helpers;

namespace API_Tutorial.Infrastructure.Entity;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [Range(4,6)]
    public Gender Gender { get; set; }

    [Required]
    public long PhoneNumber { get; set; }

    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;
}

