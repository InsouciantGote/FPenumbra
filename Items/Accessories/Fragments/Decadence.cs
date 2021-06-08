using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Accessories.Fragments
{
	public class Decadence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fragment of Decadence");
			Tooltip.SetDefault
				("+5% melee and ranged damage" +
				"\nAdditional melee and ranged damage as your health goes down" +
				"\n-5 defense" +
				"\n-100 health" +
				"\nVictims who fell down the chasms of the corrupted lands are usually eaten" +
				"\nby a worm with such size and form that is beyond normal.");
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
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamage += 0.05f;
			player.rangedDamage += 0.05f;
			player.meleeDamage += (player.statLifeMax - player.statLife) * 0.00025f;
			player.rangedDamage += (player.statLifeMax - player.statLife) * 0.00025f;
			player.statDefense -= 10;
			player.statLifeMax2 -= 100;
		}
	}
}
