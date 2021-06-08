using FPenumbra.Items.PrototypeVile;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.PrototypeVile
{
	public class EnergyCleaver : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Tags enemies with energy if not killed" +
				"\nKilling enemies with that tag will cause them to explode");
		}
		public override void SetDefaults() {
			item.damage = 37;
			item.crit = 11;
			item.melee = true;
			item.width = 52;
			item.height = 58;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.2f;
			item.value = 120000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			{ target.AddBuff(ModContent.BuffType<Buffs.EnergyCleave>(), 180); }
		}
	}
}