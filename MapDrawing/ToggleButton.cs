﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.Map;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Audio;

namespace OneBlock.MapDrawing
{
    public class ToggleButton
    {
        public Texture2D BesideTexture = ModContent.Request<Texture2D>("OneBlock/MapDrawing/Icons/IconMushroom", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;

        public bool enabled = true;

        string on = "Toggle off";
        string off = "Toggle on";

        public Point DrawPos = new(0, 0);
        public Color toggleDrawColor = Color.White;
        public Color besideIconDrawColor = Color.White;

        public float ScaleIfNotSelected = 1f;
        public float ScaleIfSelected = 1.5f;
        public int distanceBetweenBesideAndToggle = 150;

        public SoundStyle PlaySound = SoundID.MenuTick;

        public string tooltip = "";

        public void Toggle()
        {
            enabled = !enabled;
            SoundEngine.PlaySound(PlaySound);
        }
        public bool Toggled { get => enabled; }//changed
        public Texture2D ToggleTexture { get => enabled ? ModContent.Request<Texture2D>("OneBlock/MapDrawing/Icons/IconToggleOn").Value : ModContent.Request<Texture2D>("OneBlock/MapDrawing/Icons/IconToggleOff").Value; }
        public void Draw(ref MapOverlayDrawContext context, ref string text)
        {
            var result = context.Draw(ToggleTexture, new Vector2(DrawPos.X, DrawPos.Y), toggleDrawColor, new SpriteFrame(1, 1, 0, 0), ScaleIfNotSelected, ScaleIfSelected, Alignment.Center);
            context.Draw(BesideTexture, new Vector2(DrawPos.X - distanceBetweenBesideAndToggle, DrawPos.Y), besideIconDrawColor, new SpriteFrame(1, 1, 0, 0), 1f, 1f, Alignment.Center);

            if (result.IsMouseOver) { text = tooltip + (enabled ? on : off); }
            if (result.IsMouseOver && Main.mouseLeft && Main.mouseLeftRelease) { Toggle(); }
        }
    }
}
