using FPenumbra.Items.PrototypeVile;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FPenumbra.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class VileLiquidatorGreaves : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("+6% increased critical chance" +
				"\n+4% movement speed");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
			item.value = 30000;
			item.rare = ItemRarityID.Orange;
			item.defense = 7;
		}

		public override void UpdateEquip(Player player) {
			player.meleeCrit += 6;
			player.rangedCrit += 6;
			player.magicCrit += 6;
			player.thrownCrit += 6;
			player.moveSpeed += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<LiquidatorScrap>(), 20);
			recipe.AddIngredient(ItemID.Wire, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}