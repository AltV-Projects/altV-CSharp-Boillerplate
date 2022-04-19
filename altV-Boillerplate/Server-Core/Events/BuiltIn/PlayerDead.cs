using AltV.Net;
using AltV.Net.Elements.Entities;
using altV_Boillerplate.Entities;

namespace altV_Boillerplate.Events.BuiltIn
{
    internal class PlayerDead : IScript
    {
        [ScriptEvent(ScriptEventType.PlayerDead)]
        public static void OnPlayerDead(XPlayer victim, IEntity attacker, uint weapon)
        {
            // Respawn the killed player after 1000ms (1 Second)
            victim.Spawn(new(0, 0, 72), 1000);

            // Remove all blood
            victim.ClearBloodDamage();
        }
    }
}
