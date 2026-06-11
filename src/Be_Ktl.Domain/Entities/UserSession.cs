using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class UserSession : BaseEntity
{
    public Guid UserId { get; private set; }

    public User User { get; private set; } = default!;

    public string DeviceId { get; private set; } = default!;

    public string IpAddress { get; private set; } = default!;

    public string RefreshToken { get; private set; } = default!;

    public DateTime RefreshTokenExpiredAt { get; private set; }

    public DateTime ExpiredAt { get; private set; }

    public UserSession() { }

   
}