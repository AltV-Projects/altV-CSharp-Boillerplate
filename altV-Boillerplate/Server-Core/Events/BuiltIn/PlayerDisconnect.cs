using AltV.Net;
using altV_Boillerplate.Entities;

namespace altV_Boillerplate.Events.BuiltIn
{
    internal class PlayerDisconnect : IScript
    {
        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void OnPlayerDisconnect(XPlayer player, string reason)
        {
            if (!player.IsLoggedIn)
            {
                Alt.Log($"Could not save player {player.Name} because he isn't logged in.");
            }
            Alt.Log($"Player {player.Name} disconnected to our server with reason: {reason}");
        }
    }
}
