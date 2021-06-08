using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Accessories.Fragments
{
	public class Resistance : ModItem
	{
		public int Timer;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fragment of Resistance");
			Tooltip.SetDefault
				("\nTaking over 20 damage converts it to 20, then it gains a cooldown" +
				"\n-10% critical chance" +
				"\nAn old man carries a curse that causes it to transform into a demonic guardian." +
				"\nRumors say that whoever defeats the monster will be haunted by it.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(9, 13));
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 48;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Expert;
			item.expert = true;
			item.defense = 8;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeCrit -= 10;
			player.rangedCrit -= 10;
			player.magicCrit -= 10;
			player.thrownCrit -= 10;
			player.GetModPlayer<FPPlayer>().resistance = true;
		}
	}
}
