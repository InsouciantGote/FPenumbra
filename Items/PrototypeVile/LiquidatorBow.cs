using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.PrototypeVile
{
	public class LiquidatorBow: ModItem
	{
		public int Timer;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Every second shot converts a wooden arrow into an energized arrow" +
				"\nEnergized bolts explode into small homing orbs");
		}

		public override void SetDefaults()
		{
			item.damage = 42;
			item.crit = 8;
			item.ranged = true; 
			item.width = 24;
			item.height = 48;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2.5f;
			item.value = 120000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot =  ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 6.6f;
			item.useAmmo = AmmoID.Arrow;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				Timer++;
					if (Timer == 2)
						{
						if (type == ProjectileID.WoodenArrowFriendly)
						{
							type = ModContent.ProjectileType<Projectiles.PrototypeVile.LiquidatingArrow>();
							Timer = 0;
						}
					}
				}
			return true;
		}
	}
}