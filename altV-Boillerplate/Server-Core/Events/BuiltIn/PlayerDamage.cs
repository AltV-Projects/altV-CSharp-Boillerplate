using AltV.Net;
using AltV.Net.Elements.Entities;

namespace altV_Boillerplate.Events.BuiltIn
{
    internal class PlayerDamage : IScript
    {
        /**
         * So, the difference between PlayerDamage and WeaponDamage is:
         * WeaponDamage is, as the name says, damage made by a weapon
         * PlayerDamage can be anyting: world damage when jumping down a bridge,
         * getting hit by a car, getting bitten from an animal, ...
         */
        [ScriptEvent(ScriptEventType.PlayerDamage)]
        public bool OnPlayerDamage(IPlayer victim, IPlayer attacker, uint weapon, ushort healthDamage, ushort armourDamage)
        {
            // Place your logic here

            // Return false, to cancel weapon damage
            return true;
        }
    }
}
