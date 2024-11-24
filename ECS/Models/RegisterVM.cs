using System.ComponentModel.DataAnnotations;

namespace ECS.Models
{
    public class RegisterVM
    {
        // Loại bỏ UserId nếu không cần thiết
        // public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string PasswordHash { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare("PasswordHash", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = null!;

        public string? FullName { get; set; } = null!;

        public string? Avatar { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? BirthDate { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Sex { get; set; }

        // Sử dụng enum cho Roles và States
        public Role Roles { get; set; } = Role.User;
        public State States { get; set; } = State.Active;

        public DateTime CreatedAt { get; set; }

        public bool EmailVerified { get; set; } = false;

        public string? ExternalProvider { get; set; }

        public string? ProviderKey { get; set; }

        public virtual ICollection<Otprequest> Otprequests { get; set; } = new List<Otprequest>();
    }

    // Enum cho Roles và States
    public enum Role
    {
        User,
        Admin
    }

    public enum State
    {
        Active,
        Inactive
    }
}
