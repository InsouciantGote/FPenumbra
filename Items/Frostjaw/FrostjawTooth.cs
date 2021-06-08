using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Frostjaw
{
	public class FrostjawTooth : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Seems cold and durable");
		}
		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 26;
			item.maxStack = 999;
			item.value = 700;
			item.rare = ItemRarityID.Blue;
		}
		public override bool CanBurnInLava() {
			return true;
		}
	}
}