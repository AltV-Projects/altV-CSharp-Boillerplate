using AltV.Net;
using AltV.Net.Elements.Entities;
using Database;

namespace altV_Boillerplate.Entities
{
    public class XPlayer : Player
    {
        private readonly ConnectionContext databaseHandle;
        public bool IsLoggedIn { get; set; }

        public XPlayer(IntPtr nativePointer, ushort id) : base(Alt.Core, nativePointer, id)
        {
            this.databaseHandle = new ConnectionContext();
            IsLoggedIn = false;
        }

        /// <summary>
        /// Checks if the user has a recorn in the database
        /// </summary>
        /// <returns>Returns true, if the user exists inside the database</returns>
        public bool DoesHaveAccount()
        {
            try
            {
                var result = this.databaseHandle.User.Where(user =>
                    user.SocialClubId == this.SocialClubId &&
                    user.HardwareIdExHash == this.HardwareIdHash &&
                    user.HardwareIdHash == this.HardwareIdHash
                ).FirstOrDefault();
                return result != null;
            }
            catch (Exception ex)
            {
                Alt.Log($"Could not check account due an error, did you run all migrations?");
                Alt.Log(ex.Message);
            }
            return false;
        }
    }
}
