﻿using CommandSystem;
using Exiled.API.Features;
using System;


namespace Scp1956Plugin
{
    [CommandHandler(typeof(ClientCommandHandler))]
    internal class ClientCommandApart : ICommand
    {
        public string Command { get; } = "apart";

        /// <inheritdoc/>
        public string[] Aliases { get; } = new string[0];

        /// <inheritdoc/>
        public string Description { get; } = "Разбор предмета гномьей магией";

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

            if (!player.TryApartItem())
            {
                response = "Магия гномов провалилась.";
                return false;
            }

            response = "Предмет успешно разобран.";
            return true;
        }
    }
}
