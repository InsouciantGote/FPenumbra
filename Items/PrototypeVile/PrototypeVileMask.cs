using Terraria.ModLoader;
using Terraria.ID;

namespace FPenumbra.Items.PrototypeVile
{
	[AutoloadEquip(EquipType.Head)]
	public class PrototypeVileMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("V.I.L.E. Mask");
		}
		public override void SetDefaults() {
			item.width = 24;
			item.height = 26;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}

		public override bool DrawHead() {
			return false;

		}
	}
}