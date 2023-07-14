﻿namespace CleanArchitectureDemo.Domain.RequestModels;

public class RegistrationRequest
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
