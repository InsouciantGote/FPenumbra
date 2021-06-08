using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items
{
	public class LivingCherry : ModItem
	{

		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 20");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 32;
			item.maxStack = 999;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 15;
			item.useTime = 15;
			item.value = 9000;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.UseSound = SoundID.Item2;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return player.statLifeMax <= 380 || player.statLifeMax == 380;
		}

		public override bool UseItem(Player player)
		{
			player.statLifeMax += 20;
			return true;
		}
	}
}