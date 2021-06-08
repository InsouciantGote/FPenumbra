using Terraria.ModLoader;
using Terraria.ID;

namespace FPenumbra.Items.Placeable
{
	public class AmongTheFlowers : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Art made by @MilkOat_");
			//https://twitter.com/MilkOat_/status/1367012874233606147
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 54;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 5000;
			item.rare = ItemRarityID.Blue;
			item.createTile = ModContent.TileType<Tiles.AmongTheFlowers>();
			item.placeStyle = 0;
		}
	}
}