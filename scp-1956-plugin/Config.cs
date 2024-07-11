using Exiled.API.Interfaces;
using InventorySystem.Items.Usables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scp1956Plugin
{
    public class Config : IConfig
    {
        [Description("Включён ли плагин")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Здоровье Гнома")]
        public int Health { get; set; } = 500;

        [Description("Размеры гнома в каждой плоскости. X, Y, Z")]
        public Vector3 Scale { get; set; } = new Vector3(1.0f, 0.5f, 1.0f);

        [Description("Может ли гном разбирать предметы, которых нет в списке ниже")]
        public bool ShouldApartFree { get; set; } = true;

        [Description("Получаемые очки за разбор предметов")]
        public Dictionary<ItemType, int> ApartValues { get; set; } = new Dictionary<ItemType, int>()
        {
            { ItemType.GunCOM15, 10 },
            { ItemType.Medkit, 5 }
        };

        [Description("Стоимость предметов для создания")]
        public Dictionary<ItemType, int> CreateValues { get; set; } = new Dictionary<ItemType, int>()
        {
            { ItemType.GunCOM15, 20 },
            { ItemType.Medkit, 10 }
        };
    }
}
