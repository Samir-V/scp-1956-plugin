using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scp1956Plugin
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class AdminCommands : ICommand
    {
        public string Command { get; } = "scp1956";

        /// <inheritdoc/>
        public string[] Aliases { get; } = new string[0];

        /// <inheritdoc/>
        public string Description { get; } = "Превращает выбранного игрока в гнома, SCP-1956";

        /// <inheritdoc />
        public bool SanitizeResponse { get; }

        /// <inheritdoc/>
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count != 1)
            {
                response = "Неверное количество аргументов.";
                return false;
            }

            var rawId = arguments.Array[1];
            //Log.Debug($"{arguments.Array[0]}");

            var player = Player.Get(rawId);

            if (player == null)
            {
                response = $"Не найден игрок с айди {rawId}";
                return false;
            }

            player.MakeGnome();

            //player.Role.Set(RoleTypeId.ClassD, Exiled.API.Enums.SpawnReason.ForceClass);
            //player.Scale.Set(1.0f, 0.5f, 1.0f);
            //player.Health = 500;
            //player.ClearInventory();

            //player.SessionVariables["IsGnome"] = true; 
        

            response = "Гном создан.";
            return true;
        }
    }
}
