﻿using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace UltimateSkyblock.Content.Items.Bombs
{
    public class SnowBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {

            Item.useStyle = ItemUseStyleID.Swing;
            Item.shootSpeed = 4f;
            Item.shoot = ModContent.ProjectileType<SnowBombProjectile>();
            Item.width = 8;
            Item.height = 28;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 40;
            Item.useTime = 40;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = Item.buyPrice(0, 0, 20, 0);
            Item.rare = ItemRarityID.Blue;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                 .AddIngredient(ItemID.SnowBlock, 25)
                 .AddIngredient(ItemID.Bomb)
                 .AddTile(TileID.WorkBenches)
                 .Register();
        }
    }
}
