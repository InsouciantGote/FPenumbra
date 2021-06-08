using FPenumbra.Items.Frostjaw;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Weapons
{
	public class FrozenWrath : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("30% chance to shoot frostburn arrows when using normal arrows");
		}

		public override void SetDefaults()
		{
			item.damage = 13;
			item.crit = 9;
			item.ranged = true; 
			item.width = 20;
			item.height = 32;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2.5f;
			item.value = 6500;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
			item.shoot =  ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 6.6f;
			item.useAmmo = AmmoID.Arrow;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{if (Main.rand.NextFloat() < .3f)
			{
				if (type == ProjectileID.WoodenArrowFriendly)
				{
					type = ProjectileID.FrostburnArrow;
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<FrostjawTooth>(), 2);
			recipe.AddIngredient(ItemID.SnowBlock, 15);
			recipe.AddIngredient(ItemID.IceBlock, 15);
			recipe.AddTile(TileID.IceMachine);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}