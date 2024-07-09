using Exiled.API.Features;
using Exiled.API.Features.Items;
using HarmonyLib;
using PlayerRoles;
using PluginAPI.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scp1956Plugin
{
    internal static class GnomeUtils
    {
        private const string GnomeKey = "IsGnome";
        private const string GnomeScoreKey = "GnomeScore";

        public static void MakeGnome(this Player player)
        {
            if (player is null) 
            {
                return;
            }

            player.Role.Set(RoleTypeId.ClassD, Exiled.API.Enums.SpawnReason.ForceClass);
            player.Scale = Scp1956Plugin.PluginConfig.Scale;
            player.Health = Scp1956Plugin.PluginConfig.Health;
            player.ClearInventory();

            player.SessionVariables[GnomeKey] = true;
            player.SessionVariables[GnomeScoreKey] = 0;
        }

        public static void UnGnome(this Player player)
        {
            if (player is null)
            {
                return;
            }

            player.SessionVariables[GnomeKey] = false;
            player.SessionVariables[GnomeScoreKey] = 0;
        }

        public static bool IsGnome(this Player player)
        {
            if (player is null)
            {
                return false;
            }

            if (player.TryGetSessionVariable(GnomeKey, out bool isGnome)) 
            {
                return isGnome;
            }

            return false;
        }

        public static int GetGnomeScore(this Player player)
        {
            if (player is null)
            {
                return 0;
            }

            if (player.TryGetSessionVariable(GnomeScoreKey, out int gnomeScore))
            {
                return gnomeScore;
            }

            return 0;
        }

        public static bool TryApartItem(this Player player)
        {
            if (player is null)
            {
                return false;
            }

            var currentItem = player.CurrentItem;
            var itemType = currentItem.Base.ItemTypeId;

            if (!Scp1956Plugin.PluginConfig.ApartValues.TryGetValue(itemType, out int value))
            {
                value = 0;
            }

            value = Math.Max(0, value);

            if (value is 0 && !Scp1956Plugin.PluginConfig.ShouldApartFree)
            {
                return false;
            }

            player.SessionVariables[GnomeScoreKey] = player.GetGnomeScore() + value;

            player.RemoveItem(currentItem);

            return true;
        }

        public static bool TryCreateItems(this Player player)
        {
            if (player is null)
            {
                return false;
            }

            int currentScore = player.GetGnomeScore();

            var itemsList = new List<(ItemType, int)>();

            foreach (var item in Scp1956Plugin.PluginConfig.CreateValues)
            {
                int value = item.Value;
                var itemType = item.Key;

                if (value > 0) 
                {
                    int maxItemCount = currentScore / value;

                    if (maxItemCount > 0)
                    {
                        itemsList.Add((itemType, maxItemCount));
                    }
                }
            }

            if (itemsList.Count == 0)
            {
                return false;
            }

            int idx = UnityEngine.Random.Range(0, itemsList.Count);

            var (creationType, itemCount) = itemsList[idx];

            var playerPos = player.Position;

            for (int i = 0; i < itemCount; ++i)
            {
                var item = Item.Create(creationType);
                item.CreatePickup(playerPos);
            }

            return true;
        }
    }
}
