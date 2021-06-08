using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.PrototypeVile
{
	public class LiquidatorScrap : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Reusable remains of the liquidating exanimates");
		}
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 28;
			item.maxStack = 999;
			item.value = 25000;
			item.rare = ItemRarityID.Orange;
		}
		public override bool CanBurnInLava() {
			return false;
		}
	}
}