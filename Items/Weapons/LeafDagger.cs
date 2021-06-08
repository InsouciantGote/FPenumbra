using FPenumbra.Items.Frostjaw;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Weapons
{
	public class LeafDagger : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots leaves on your direction" +
				"\nLeaf speed depends on how high or low your cursor is positioned");
		}

		public override void SetDefaults()
		{
			item.damage = 14;
			item.crit = 10;
			item.width = 24;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.melee = true;
			item.noMelee = false;
			item.knockBack = 3;
			item.value = 8000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("LeafDaggerLeaf");
			item.shootSpeed = 5f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EnchantedWood>(), 12);
			recipe.AddIngredient(ItemID.FallenStar, 2);
			recipe.AddTile(TileID.LivingLoom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}