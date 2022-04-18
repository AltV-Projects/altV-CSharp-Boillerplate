using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace altV_Boillerplate.Events.BuiltIn
{
    internal class WeaponDamage : IScript
    {
        [ScriptEvent(ScriptEventType.WeaponDamage)]
        public static bool OnWeaponDamage(IPlayer victim, IEntity attacker, uint weapon, ushort damage, Position offset, BodyPart bodyPart)
        {
            // Place your logic here

            // Return false, to cancel weapon damage
            return true;
        }
    }
}
