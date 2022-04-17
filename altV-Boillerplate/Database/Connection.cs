namespace Database
{
    public class Connection
    {
        private static ConnectionContext context = new();

        /// <summary>
        /// Checks, if the script can connect to the database
        /// </summary>
        /// <returns>Returns true on success, otherwise it throws an exception</returns>
        public static bool CanConnect()
        {

            return context.Database.CanConnect();
        }
    }
}
