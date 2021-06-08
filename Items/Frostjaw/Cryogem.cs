using Terraria.ModLoader;
using Terraria.ID;

namespace FPenumbra.Items.Frostjaw
{
	public class Cryogem : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 28;
			item.maxStack = 999;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
		}
		public override bool CanBurnInLava() {
			return true;
		}
	}
}