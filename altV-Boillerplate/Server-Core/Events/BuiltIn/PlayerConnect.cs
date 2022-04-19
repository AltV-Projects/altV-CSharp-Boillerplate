using AltV.Net;
using AltV.Net.Enums;
using altV_Boillerplate.Entities;

namespace altV_Boillerplate.Events.BuiltIn
{
    internal class PlayerConnect : IScript
    {
        [ScriptEvent(ScriptEventType.PlayerConnect)]

        public void OnPlayerConnect(XPlayer player, string reason)
        {
            player.Model = (uint)PedModel.FreemodeMale01; // Set to default model
            player.Spawn(new(0, 0, 72), 1000); // Set to default spawn
            Alt.Log($"Player {player.Name} connected to our server.");

            if (player.DoesHaveAccount())
            {
                Alt.Log($"{player.Name} has a record in the database.");
                player.Login("dummy@mail.com");
            }
            else
            {
                Alt.Log($"{player.Name} has no record in the database.");
                player.Register("dummy@mail.com");
            }
            Alt.Log($"Set player.DBID to {player.DBID}");
        }
    }
}
