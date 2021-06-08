using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Weapons
{
	public class BowOfFocus : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bow of Focus");
			Tooltip.SetDefault("Shoots an additional arrow that ignores gravity" +
				"\nThat arrow will deal half the bow's damage.");
		}

		public override void SetDefaults()
		{
			item.damage = 14;
			item.crit = 7;
			item.ranged = true; 
			item.width = 20;
			item.height = 36;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 8000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
			item.shoot =  ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 6.6f;
			item.useAmmo = AmmoID.Arrow;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
			speedX = perturbedSpeed.X/3;
			speedY = perturbedSpeed.Y/3;
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FocusedArrow"), damage/2, knockBack, player.whoAmI);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EnchantedWood>(), 15);
			recipe.AddIngredient(ItemID.FallenStar, 2);
			recipe.AddTile(TileID.LivingLoom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}