﻿using System.ComponentModel.DataAnnotations;

namespace WebServicesAgriPure.Security.Services.Communication;

public class AuthenticateRequest
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
}