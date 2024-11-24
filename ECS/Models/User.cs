using System;
using System.Collections.Generic;

namespace ECS.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Avatar { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Address { get; set; }

    public string Roles { get; set; } = null!;

    public string States { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Sex { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? ExternalProvider { get; set; }

    public string? ProviderKey { get; set; }

    public bool EmailVerified { get; set; }

    public virtual ICollection<Otprequest> Otprequests { get; set; } = new List<Otprequest>();
}
