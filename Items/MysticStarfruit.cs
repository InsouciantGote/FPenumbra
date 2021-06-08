using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items
{
	public class MysticStarfruit : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum mana by 20");
		}

		public override void SetDefaults() {
			item.width = 34;
			item.height = 30;
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
			return player.statManaMax <= 180 || player.statLifeMax == 180;
		}

		public override bool UseItem(Player player)
		{
			player.statManaMax += 20;
			return true;
		}
	}
}