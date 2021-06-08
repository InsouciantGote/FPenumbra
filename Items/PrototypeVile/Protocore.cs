using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.PrototypeVile
{
	public class Protocore : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Emits strange signals");
		}
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 28;
			item.maxStack = 999;
			item.value = 3000;
			item.rare = ItemRarityID.Green;
		}
		public override bool CanBurnInLava() {
			return false;
		}
	}
}