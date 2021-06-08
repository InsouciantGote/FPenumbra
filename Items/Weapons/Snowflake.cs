using FPenumbra.Items.Frostjaw;
using FPenumbra.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Weapons
{
	public class Snowflake : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("Fires shards as you launch the weapon");
		}
        public override void SetDefaults()
		{
			item.width = 30;
			item.height = 32;
			item.value = 7000;
			item.rare = ItemRarityID.Blue;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 4.6f;
			item.damage = 25;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<SnowflakeFlail>();
			item.shootSpeed = 15.1f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.crit = 8;
			item.channel = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Cryogem>(), 5);
			recipe.AddIngredient(ModContent.ItemType<FrostjawTooth>(), 7);
			recipe.AddIngredient(ItemID.SnowBlock, 15);
			recipe.AddIngredient(ItemID.IceBlock, 5);
			recipe.AddTile(TileID.IceMachine);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
