using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Frostjaw
{
	public class FrostboltStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots frostbolts that inflict frostburn" +
				"\nIf the first target hit gets or has frostburn, that projectile deals more damage");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 18;
			item.crit = 6;
			item.width = 108;
			item.height = 126;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.magic = true;
			item.mana = 8;
			item.knockBack = 3f;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Blue;  
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FrostboltProjectile");
			item.shootSpeed = 5f;
		}
	}
}