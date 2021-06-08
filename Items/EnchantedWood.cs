using Terraria.ModLoader;
using Terraria.ID;

namespace FPenumbra.Items
{
	public class EnchantedWood : ModItem
	{
		public override void SetStaticDefaults()
		{
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 22;
			item.maxStack = 999;
			item.value = 500;
			item.rare = ItemRarityID.Blue;
		}
		public override bool CanBurnInLava() {
			return true;
		}
	}
}