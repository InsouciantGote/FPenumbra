using FPenumbra.Items.PrototypeVile;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class VileLiquidatorSuit : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			Tooltip.SetDefault("+6% increased damage");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 22;
			item.value = 40000;
			item.rare = ItemRarityID.Orange;
			item.defense = 9;
		}

		public override void UpdateEquip(Player player) {
			player.allDamage += 0.06f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<LiquidatorScrap>(), 25);
			recipe.AddIngredient(ItemID.Wire, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}