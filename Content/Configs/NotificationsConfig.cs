﻿using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace UltimateSkyblock.Content.Configs
{
    public class NotificationsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        public bool EnabledNotifs { get; set; }
    }
}
