using FPenumbra.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FPenumbra.Items.Banners
{
	public class FrostjawBanner : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Nearby players get a bonus against: Frostjaw");
		}
		public override void SetDefaults() {
			item.width = 10;
			item.height = 24;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.rare = ItemRarityID.Blue;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = ModContent.TileType<MonsterBanner>();
			item.placeStyle = 0;
		}
	}
}
