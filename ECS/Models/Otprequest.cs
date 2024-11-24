using System;
using System.Collections.Generic;

namespace ECS.Models;

public partial class Otprequest
{
    public int OtpId { get; set; }

    public int UserId { get; set; }

    public string OtpCode { get; set; } = null!;

    public DateTime ExpirationTime { get; set; }

    public string Purpose { get; set; } = null!;

    public bool? IsUsed { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? AttemptsLeft { get; set; }

    public virtual User User { get; set; } = null!;
}
