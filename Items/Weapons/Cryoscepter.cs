using FPenumbra.Items.Frostjaw;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Weapons
{
	public class Cryoscepter : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.staff[item.type] = true;
			Tooltip.SetDefault("Hitting enemies reverses projectile direction");
		}
		public override void SetDefaults() {
			item.damage = 19;
			item.crit = 12;
			item.magic = true;
			item.width = 34;
			item.height = 34;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 2;
			item.value = 7000;
			item.noMelee = true;
			item.mana = 9;
			item.rare = ItemRarityID.Blue;
			item.shoot = mod.ProjectileType("CryoscepterProjectile");
			item.shootSpeed = 3;
			item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Cryogem>(), 8);
			recipe.AddIngredient(ModContent.ItemType<FrostjawTooth>(), 3);
			recipe.AddIngredient(ItemID.SnowBlock, 10);
			recipe.AddIngredient(ItemID.IceBlock, 10);
			recipe.AddTile(TileID.IceMachine);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}