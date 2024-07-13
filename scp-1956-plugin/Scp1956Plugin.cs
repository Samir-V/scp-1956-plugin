using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Scp1956Plugin
{
    internal class Scp1956Plugin : Plugin<Config>
    {
        public static Scp1956Plugin Instance { get; private set; } = new Scp1956Plugin();

        public static Config PluginConfig => Instance.Config;

        private Scp1956Plugin() { }

        private PlayerHandler playerHandler;

        public override string Name { get; } = "SCP-1956";

        public override string Prefix { get; } = "scp1956";

        public override string Author { get; } = "SamV";

        public override PluginPriority Priority { get; } = PluginPriority.Default;

        public override System.Version Version { get; } = new System.Version(1, 0, 2);

        public override void OnEnabled()
        {
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            playerHandler = new PlayerHandler();
            Exiled.Events.Handlers.Player.ChangingRole += playerHandler.OnChangingRole;
        }

        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.ChangingRole -= playerHandler.OnChangingRole;
            playerHandler = null;
        }
    }
}
