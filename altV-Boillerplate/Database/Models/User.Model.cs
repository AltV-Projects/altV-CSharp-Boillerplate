namespace Database.Models
{
    public class User : Base
    {
        public string Mail { get; set; } = default!;
        public float PosX { get; set; } = 0;
        public float PosY { get; set; } = 0;
        public float PosZ { get; set; } = 72;
        public float PosR { get; set; } = 0;
        public ulong SocialClubId { get; set; } = default!;
        public ulong HardwareIdExHash { get; set; } = default!;
        public ulong HardwareIdHash { get; set; } = default!;
        public string Token { get; set; } = default!;
        public bool Verified { get; set; } = false;
    }
}
