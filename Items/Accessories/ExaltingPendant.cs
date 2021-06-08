using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class ExaltingPendant : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Non-boss frostjaws become harmless");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 32;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 40);
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.npcTypeNoAggro[ModContent.NPCType<NPCs.Frostjaw.FrostjawHead>()] = true;
			player.npcTypeNoAggro[ModContent.NPCType<NPCs.Frostjaw.FrostjawBody>()] = true;
			player.npcTypeNoAggro[ModContent.NPCType<NPCs.Frostjaw.FrostjawTail>()] = true;
		}
	}
}
