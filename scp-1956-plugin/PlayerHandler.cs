using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scp1956Plugin
{
    internal sealed class PlayerHandler
    {
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            ev.Player.UnGnome();
        }
    }
}
