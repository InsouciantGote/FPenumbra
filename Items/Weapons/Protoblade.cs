using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Weapons
{
	public class Protoblade : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Slashes hit twice and change direction");
		}
		public override void SetDefaults()
		{
			item.damage = 16;
			item.crit = 4;
			item.melee = true;
			item.width = 36;
			item.height = 42;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noUseGraphic = true;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item15;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("ProtobladeSlash1");
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			{
				type = Main.rand.Next(new int[] { type, mod.ProjectileType("ProtobladeSlash2")});
				return true;
			}
		}
	}
}