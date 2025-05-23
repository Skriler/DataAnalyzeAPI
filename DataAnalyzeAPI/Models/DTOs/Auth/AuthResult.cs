﻿namespace DataAnalyzeApi.Models.DTOs.Auth;

public record AuthResult
{
    public bool Success { get; set; }

    public string Error { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public DateTime Expiration { get; set; }

    public string Username { get; set; } = string.Empty;

    public List<string> Roles { get; set; } = new();
}
