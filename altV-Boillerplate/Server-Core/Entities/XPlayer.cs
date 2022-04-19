using AltV.Net;
using AltV.Net.Elements.Entities;
using Database;
using Database.Models;

namespace altV_Boillerplate.Entities
{
    public class XPlayer : Player
    {
        private readonly ConnectionContext databaseHandle;
        public int DBID { get; set; } = -1;
        public bool IsLoggedIn { get; set; }
        private User _lastUser = new();

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
                    user.HardwareIdExHash == this.HardwareIdExHash &&
                    user.HardwareIdHash == this.HardwareIdHash
                ).FirstOrDefault();
                this._lastUser = result;
                return result != null;
            }
            catch (Exception ex)
            {
                Alt.Log($"Could not check account due an error, did you run all migrations?");
                Alt.Log(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Performs a login with the given mail address
        /// </summary>
        /// <param name="mail">E-Mail Address to check against the database</param>
        /// <returns>Returns true, if everything went well</returns>
        public bool Login(string mail)
        {
            try
            {
                var result = this.databaseHandle.User.Where(user =>
                    user.Mail == mail
                ).FirstOrDefault();
                if (result == null) return false;

                if (
                    result.SocialClubId == this.SocialClubId &&
                    result.HardwareIdExHash == this.HardwareIdExHash &&
                    result.HardwareIdHash == this.HardwareIdHash
                  )
                {
                    this.DBID = result.Id;
                    this.IsLoggedIn = true;
                    this._lastUser = result;
                }
            }
            catch (Exception ex)
            {
                Alt.Log(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            return this.IsLoggedIn;
        }

        /// <summary>
        /// Performs a registration with the given mail address
        /// </summary>
        /// <param name="mail">E-Mail Address to insert into the database</param>
        /// <returns>Returns true, if everything went well</returns>
        public bool Register(string mail)
        {
            Random rand = new Random();

            try
            {
                var userAccount = new User();
                userAccount.Mail = mail;
                userAccount.SocialClubId = this.SocialClubId;
                userAccount.HardwareIdExHash = this.HardwareIdExHash;
                userAccount.HardwareIdHash = this.HardwareIdHash;
                userAccount.Token = rand.Next(1500, 9999).ToString();

                var result = this.databaseHandle.Add(userAccount);
                this.databaseHandle.SaveChanges();
                this._lastUser = userAccount;
                return result != null;
            }
            catch (Exception ex)
            {
                Alt.Log(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            return false;
        }
    }
}
