using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Frostjaw
{
	public class FrostjawsBreath : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostjaw's Breath");
			Tooltip.SetDefault("Uses gel for ammo" +
				"\nShoots lines of frostburn flames" +
				"\nDoes not extiguish in water" +
				"\n10% chance to not consume ammo");
		}

		public override void SetDefaults()
		{
			item.damage = 9;
			item.crit = 5;
			item.width = 78;
			item.height = 22;
			item.useTime = 5;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.ranged = true;
			item.knockBack = 0.5f;
			item.UseSound = SoundID.Item34;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Blue;  
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FrostjawsBreathFlame");
			item.shootSpeed = 8f;
			item.useAmmo = AmmoID.Gel;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 0);
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() > .15f;
		}
	}
}