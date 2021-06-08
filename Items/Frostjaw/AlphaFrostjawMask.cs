using Terraria.ModLoader;
using Terraria.ID;

namespace FPenumbra.Items.Frostjaw
{
	[AutoloadEquip(EquipType.Head)]
	public class AlphaFrostjawMask : ModItem
	{
		public override void SetDefaults() {
			item.width = 28;
			item.height = 22;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}

		public override bool DrawHead() {
			return false;

		}
	}
}