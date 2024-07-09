using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scp1956Plugin
{
    [CommandHandler(typeof(ClientCommandHandler))]
    internal class ClientCommandCreate : ICommand
    {
        public string Command { get; } = "create";

        /// <inheritdoc/>
        public string[] Aliases { get; } = new string[0];

        /// <inheritdoc/>
        public string Description { get; } = "A simple test command.";

        /// <inheritdoc />
        public bool SanitizeResponse { get; }

        /// <inheritdoc/>
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender); 

            if (!player.IsGnome())
            {
                response = "Вы не гном.";
                return false;
            }

            if (!player.TryCreateItems())
            {
                response = "Магия гномов провалилась.";
                return false;
            }

            response = "Успех!";
            return true;
        }
    }
}
