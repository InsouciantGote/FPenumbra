using FPenumbra.Items.Accessories.Fragments;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items
{
	public class BossBags : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg) {
			// This method shows adding items to Fishrons boss bag. 
			// Typically you'll also want to also add an item to the non-expert boss drops, that code can be found in ExampleGlobalNPC.NPCLoot. Use this and that to add drops to bosses.
			if (context == "bossBag" && arg == ItemID.KingSlimeBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<Insistence>());
			}
			if (context == "bossBag" && arg == ItemID.EyeOfCthulhuBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<Vigilance>());
			}
			if (context == "bossBag" && arg == ItemID.EaterOfWorldsBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<Decadence>());
			}
			if (context == "bossBag" && arg == ItemID.BrainOfCthulhuBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<Intelligence>());
			}
			if (context == "bossBag" && arg == ItemID.QueenBeeBossBag)
			{
				player.QuickSpawnItem(ModContent.ItemType<Prevalence>());
			}
		}
	}
}