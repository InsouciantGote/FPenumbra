using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Accessories.Fragments
{
	public class Prevalence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fragment of Prevalence");
			Tooltip.SetDefault
				("+1 minion slot" +
				"\n+10% minion damage" +
				"\n-15% damage reduction" +
				"\nAlthough they're not in their hive to protect their larvae, their queen" +
				"\nabhors creatures that dare to destroy them.");
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
			player.maxMinions += 1;
			player.minionDamage += 0.1f;
			player.endurance -= 0.15f;
		}
	}
}
