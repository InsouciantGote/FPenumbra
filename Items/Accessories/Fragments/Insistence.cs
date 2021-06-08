using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Accessories.Fragments
{
	public class Insistence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fragment of Insistence");
			Tooltip.SetDefault
				("50% jump boost" +
				"\nReduces defense by 8" +
				"\nAlthough insubstantial, the resilience of slimes makes themselves an" +
				"\nexasperating foe.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(9, 13));
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 48;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Expert;
			item.expert = true;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.jumpBoost = true;
			player.jumpSpeedBoost = 0.50f;
			player.statDefense -= 8;
		}
	}
}
