using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;

namespace FPenumbra.Items.PrototypeVile
{
	public class PrototypeVileBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}
		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Expert;
			item.expert = true;
		}

		public override bool CanRightClick() {
			return true;
		}
		public override void OpenBossBag(Player player)
		{
			player.QuickSpawnItem(ModContent.ItemType<Items.PrototypeVile.LiquidatorScrap>(), Main.rand.Next(18, 30));
			player.QuickSpawnItem(ModContent.ItemType<Accessories.Fragments.Virulence>());
			{
				var dropChooser1 = new WeightedRandom<int>();
				dropChooser1.Add(ModContent.ItemType<Items.PrototypeVile.EnergyCleaver>());
				dropChooser1.Add(ModContent.ItemType<Items.PrototypeVile.LiquidatorBow>());
				dropChooser1.Add(ModContent.ItemType<Items.PrototypeVile.Protoblaster>());
				dropChooser1.Add(ModContent.ItemType<Projectiles.Minions.VileDrones.VileDroneItem>());
				int choice1 = dropChooser1;
				player.QuickSpawnItem(choice1);
				var dropChooser2 = new WeightedRandom<int>();
				dropChooser2.Add(ModContent.ItemType<Items.PrototypeVile.EnergyCleaver>());
				dropChooser2.Add(ModContent.ItemType<Items.PrototypeVile.LiquidatorBow>());
				dropChooser2.Add(ModContent.ItemType<Items.PrototypeVile.Protoblaster>());
				dropChooser2.Add(ModContent.ItemType<Projectiles.Minions.VileDrones.VileDroneItem>());
				int choice2 = dropChooser2;
				player.QuickSpawnItem(choice2);
			}
		}
		public override int BossBagNPC => ModContent.NPCType<NPCs.PrototypeVile.PrototypeVile>();
	}
}