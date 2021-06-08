using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.VanillaAlter
{
	public class VanillaRecipes : GlobalItem
	{
		public override void AddRecipes()
		{
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.SnowBlock, 30);
				recipe.AddIngredient(ItemID.IceBlock, 30);
				recipe.AddIngredient(ItemID.IronBar, 5);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(ItemID.IceMachine);
				recipe.AddRecipe();
			}
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.SnowBlock, 30);
				recipe.AddIngredient(ItemID.IceBlock, 30);
				recipe.AddIngredient(ItemID.LeadBar, 5);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(ItemID.IceMachine);
				recipe.AddRecipe();
			}
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<EnchantedWood>(), 15);
				recipe.AddTile(TileID.WorkBenches);
				recipe.SetResult(ItemID.LivingLoom);
				recipe.AddRecipe();
			}
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<EnchantedWood>(), 10);
				recipe.AddIngredient(ItemID.FallenStar, 2);
				recipe.AddTile(TileID.LivingLoom);
				recipe.SetResult(ItemID.LivingWoodWand);
				recipe.AddRecipe();
			}
			{
				ModRecipe recipe = new ModRecipe(mod);	
				recipe.AddIngredient(ModContent.ItemType<EnchantedWood>(), 10);
				recipe.AddIngredient(ItemID.FallenStar, 2);
				recipe.AddTile(TileID.WorkBenches);
				recipe.SetResult(ItemID.LeafWand);
				recipe.AddRecipe();
			}
		}
	}
}