using AltV.Net;
using AltV.Net.Elements.Entities;
using altV_Boillerplate.Entities;

namespace altV_Boillerplate.Events.ResourceHandler
{
    internal class StartStop : Resource
    {
        public override void OnStart()
        {
            Alt.Log("Server is starting");
            Alt.Log("Testing Database connection...");
            try
            {
                Database.Connection.CanConnect();
                Alt.Log("Database connection successfull!");
            }
            catch (Exception ex)
            {
                Alt.Log($"Could not connect to database, error: {ex.Message}");
                Thread.Sleep(5000);
                Environment.Exit(-1);
            }
        }

        public override void OnStop()
        {
            Alt.Log("Server is shooting down");
            foreach (XPlayer player in Alt.GetAllPlayers())
            {
                if (!player.Exists) continue;
                if (!player.IsConnected) continue;
                if (!player.IsLoggedIn) continue;

                player.Save();
            }
        }


        public override IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new XPlayerFactory();
        }
    }
}
