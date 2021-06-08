using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;

namespace FPenumbra.Items.Frostjaw
{
	public class AlphaFrostjawBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}
		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Expert;
			item.expert = true;
		}

		public override bool CanRightClick() {
			return true;
		}
		public override void OpenBossBag(Player player)
		{
			player.QuickSpawnItem(ModContent.ItemType<FrostjawTooth>(), Main.rand.Next(8, 15));
			player.QuickSpawnItem(ModContent.ItemType<Accessories.Fragments.Compliance>());
                {
                    var dropChooser1 = new WeightedRandom<int>();
                    dropChooser1.Add(ModContent.ItemType<Items.Frostjaw.IcicleSpear>());
                    dropChooser1.Add(ModContent.ItemType<Items.Frostjaw.FrostjawsBreath>());
                    dropChooser1.Add(ModContent.ItemType<Items.Frostjaw.FrostboltStaff>());
                    dropChooser1.Add(ModContent.ItemType<Projectiles.Minions.IceFragments.IceFragmentItem>());
                    int choice1 = dropChooser1;
					player.QuickSpawnItem(choice1);
                }
                {
					var dropChooser2 = new WeightedRandom<int>();
					dropChooser2.Add(ModContent.ItemType<Items.Frostjaw.IcicleSpear>());
					dropChooser2.Add(ModContent.ItemType<Items.Frostjaw.FrostjawsBreath>());
					dropChooser2.Add(ModContent.ItemType<Items.Frostjaw.FrostboltStaff>());
					dropChooser2.Add(ModContent.ItemType<Projectiles.Minions.IceFragments.IceFragmentItem>());
					int choice2 = dropChooser2;
					player.QuickSpawnItem(choice2);
				}
		}
		public override int BossBagNPC => ModContent.NPCType<NPCs.Frostjaw.AlphaFrostjawHead>();
	}
}