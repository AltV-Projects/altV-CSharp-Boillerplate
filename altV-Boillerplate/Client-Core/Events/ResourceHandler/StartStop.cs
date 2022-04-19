using AltV.Net.Client;

namespace Client_Core.Events.Builtin
{
    internal class StartStop : Resource
    {
        public override void OnStart()
        {
            Alt.LogInfo("Client Started!");
        }

        public override void OnStop()
        {
            Alt.LogInfo("Client Stopped!");
        }
    }
}
