using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FPenumbra.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class EnchantedGreaves : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("6% increased movement speed");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
			item.value = 8000;
			item.rare = ItemRarityID.Blue;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.06f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EnchantedWood>(), 25);
			recipe.AddTile(TileID.LivingLoom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}