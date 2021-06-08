using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Accessories.Expert
{
	public class FrozenHeart : ModItem
	{
	public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("You gain 7 more defense for 6 seconds when hurt" +
				"\nPress Stasis hotkey to activate cryostasis for 4 seconds" +
				"\nWhile in stasis, you won't take any damage but you'll be frozen" +
				"\nDoes not ignore debuffs and debuff damage" +
				"\nThis stasis gives a 2-minute cooldown after use");
		}

		public override void SetDefaults()
		{
			item.defense = 4;
			item.width = 34;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Expert;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<FPPlayer>().frozenheart = true;
		}
	}
}
