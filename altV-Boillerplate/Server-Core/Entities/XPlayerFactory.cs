using AltV.Net;
using AltV.Net.Elements.Entities;

namespace altV_Boillerplate.Entities
{
    internal class XPlayerFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(ICore server, IntPtr playerPointer, ushort id)
        {
            return new XPlayer(playerPointer, id);
        }

    }
}
