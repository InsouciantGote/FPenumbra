using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Frostjaw
{
	public class BlizzardCore : ModItem 
	{
	public override void SetStaticDefaults() {
			Tooltip.SetDefault("Non-consumable" +
				"\nSummons the Alpha Frostjaw" +
				"\nCreates weather anomalies while the creature is active");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 2;
		}

		public override void SetDefaults() {
			item.width = 54;
			item.height = 54;
			item.maxStack = 1;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.value = 50000;
			item.consumable = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBlock, 50);
			recipe.AddIngredient(ItemID.SnowBlock, 50);
			recipe.AddIngredient(ModContent.ItemType<FrostjawTooth>(),5);
			recipe.AddIngredient(ItemID.Sapphire);
			recipe.AddTile(TileID.IceMachine);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool CanUseItem(Player player) {
			return player.ZoneSnow && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Frostjaw.AlphaFrostjawHead>());
		}

		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Frostjaw.AlphaFrostjawHead>());
			Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/AlphaFrostjawRoar"));
			if (Main.rand.NextBool(2))
			{
				if (Main.rand.NextBool(2))
				{ Main.NewText("Weather anomalies occurring!", 175, 235, 255); }
				else
				{ Main.NewText("Heavy blizzard approaching!", 175, 235, 255); }
			}
			else
			{
				if (Main.rand.NextBool(2))
				{ Main.NewText("Weather amplification successful!", 175, 235, 255); }
				else
				{ Main.NewText("Incoming high levels of winds!", 175, 235, 255); }
			}
			return true;
		}
	}
}