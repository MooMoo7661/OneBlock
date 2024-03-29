﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.IO;
using Terraria.WorldBuilding;
using UltimateSkyblock.Content.Items.Placeable;
using static UltimateSkyblock.Content.Subworlds.MiningSubworld;

namespace UltimateSkyblock.Content.Subworlds.Passes
{
    public class DeepstonePass : GenPass
    {
        public DeepstonePass(string name, double loadWeight) : base(name, loadWeight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating Deepstone";
            for (int x = 0; x < Main.maxTilesX; x++)
            {
                for (int y = Main.UnderworldLayer - 205; y < Main.UnderworldLayer - 200; y++)
                {
                    WorldGen.TileRunner(x, y + Main.rand.Next(-6, 6), Main.rand.Next(5, 12), Main.rand.Next(2, 5), MiningSubworld.Deepstone, true);
                    progress.Set((y + x * Main.maxTilesY) / (float)(Main.maxTilesX * Main.maxTilesY));
                }

                for (int y = Main.UnderworldLayer - 205; y < Main.maxTilesY; y++)
                {
                    if (Framing.GetTileSafely(x, y).TileType == TileID.Stone || Framing.GetTileSafely(x, y).TileType == MiningSubworld.Slate)
                    {
                        Framing.GetTileSafely(x, y).ClearTile();
                        WorldGen.PlaceTile(x, y, MiningSubworld.Deepstone, true);
                    }
                    progress.Set((y + x * Main.maxTilesY) / (float)(Main.maxTilesX * Main.maxTilesY));
                }
            }
        }
    }
}
