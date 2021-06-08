using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Frostjaw
{
	public class IcicleSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots short-ranged icicles");
		}

		public override void SetDefaults()
		{
			item.damage = 18;
			item.crit = 10;
			item.width = 54;
			item.height = 54;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = false;
			item.melee = true;
			item.noUseGraphic = true;
			item.knockBack = 3.5f;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Blue;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("IcicleSpearSpear");
			item.shootSpeed = 4f;
		}
		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(32));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("IcicleSpearIcicle"), damage, knockBack, player.whoAmI);
			return true;
		}
	}
}