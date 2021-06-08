using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FPenumbra.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class CryomancerBeanie : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cryomancer's Beanie");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 14;
			item.value = 2000;
			item.rare = ItemRarityID.White;
			item.vanity = true;
		}

        public override void UpdateVanity(Player player, EquipType type)
        {
			player.GetModPlayer<FPPlayer>().cryobean = true;
        }
        public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<FPPlayer>().cryobean = true;
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true;
		}
	}
}