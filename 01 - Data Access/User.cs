using System;
using System.Collections.Generic;

namespace CarRental;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public DateTime? BirthDate { get; set; }

    public byte Sex { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? UserImageName { get; set; }

    public byte[]? UserImagePath { get; set; }

    public string? UserRole { get; set; }
}
