using CommandSystem;
using Exiled.API.Features;
using System;

namespace Scp1956Plugin.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    internal class ClientCommandCreate : ICommand
        {
            public string Command { get; } = "gnomescore";

            /// <inheritdoc/>
            public string[] Aliases { get; } = new string[0];

            /// <inheritdoc/>
            public string Description { get; } = "Проверка количества очков гнома";

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

                int score = player.GetGnomeScore();

                response = $"У вас {score} очков гнома";
                return true;
            }
        }
}
