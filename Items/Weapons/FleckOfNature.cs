using FPenumbra.Items.Frostjaw;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Weapons
{
	public class FleckOfNature : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fleck of Nature");
		}
		public override void SetDefaults() {
			item.damage = 6;
			item.crit = 5;
			item.magic = true;
			item.width = 30;
			item.height = 34;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 0;
			item.value = 7000;
			item.noMelee = true;
			item.mana = 9;
			item.rare = ItemRarityID.Blue;
			item.shoot = mod.ProjectileType("FleckOfNatureProjectile");
			item.shootSpeed = 4;
			item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EnchantedWood>(), 10);
			recipe.AddIngredient(ItemID.Book);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.Bookcases);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}