using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.PrototypeVile
{
	public class Protoblaster : ModItem
	{
		public override void SetDefaults() {
			item.damage = 40;
			item.crit = 9;
			item.magic = true;
			item.width = 42;
			item.height = 28;
			item.useTime = 38;
			item.useAnimation = 38;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 0;
			item.value = 120000;
			item.noMelee = true;
			item.mana = 12;
			item.rare = ItemRarityID.Orange;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Protoblaster");
			item.shoot = mod.ProjectileType("Protolaser");
			item.shootSpeed = 20;
			item.autoReuse = true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 10, 10, position + muzzleOffset, 10, 10))
			{
				position += muzzleOffset;
			}
			return true;
		}
	}
}