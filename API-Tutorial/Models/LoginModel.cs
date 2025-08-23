using System;
using System.ComponentModel.DataAnnotations;
namespace API_Tutorial.Models;

public class LoginModel
{
	[Required]
	public string? LoginId { get; set; }

	[Required]
	public string? Password { get; set; }
}

