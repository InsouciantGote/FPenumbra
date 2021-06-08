using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Weapons
{
	public class CryomancersSpellbook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryomancer's Spellbook");
		}
		public override void SetDefaults() {
			item.damage = 25;
			item.crit = 6;
			item.magic = true;
			item.width = 30;
			item.height = 36;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 3;
			item.value = 25000;
			item.noMelee = true;
			item.mana = 12;
			item.rare = ItemRarityID.Blue;
			item.shoot = mod.ProjectileType("CryomancerProjectile");
			item.shootSpeed = 2;
			item.autoReuse = true;
		}
	}
}