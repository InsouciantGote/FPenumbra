using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace FPenumbra.Items.PrototypeVile
{
	public class Protobeacon : ModItem 
	{
	public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons the Virulent Intelligent Liquidiating Exanimate");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 5;
		}

		public override void SetDefaults() {
			item.width = 50;
			item.height = 50;
			item.maxStack = 20;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.value = 60000;
			item.consumable = true;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
		public override bool CanUseItem(Player player) {
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.PrototypeVile.PrototypeVile>());
		}

		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.PrototypeVile.PrototypeVile>());
			Main.PlaySound(SoundID.ForceRoar, player.position, 0);
			return true;
		}
		public override void AddRecipes()
		{
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<Protocore>(), 1);
				recipe.AddIngredient(ItemID.IronBar, 5);
				recipe.AddIngredient(ItemID.Wire, 30);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<Protocore>(), 1);
				recipe.AddIngredient(ItemID.LeadBar, 5);
				recipe.AddIngredient(ItemID.Wire, 30);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}