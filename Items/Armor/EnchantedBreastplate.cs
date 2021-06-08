using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class EnchantedBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			Tooltip.SetDefault("5% increased damage"
				+ "\nIncreases life regen");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 22;
			item.value = 9000;
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player) {
			player.lifeRegen += 1;
			player.allDamage += 0.05f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EnchantedWood>(), 30);
			recipe.AddTile(TileID.LivingLoom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}