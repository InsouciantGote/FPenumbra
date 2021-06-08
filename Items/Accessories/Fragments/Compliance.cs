using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Accessories.Fragments
{
	public class Compliance : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fragment of Compliance");
			Tooltip.SetDefault
				("Non-boss frostjaws no longer spawn" +
				"\n20% increased pick speed" +
				"\n20% decreased movement speed" +
				"\n40% decreased acceleration speed" +
				"\nThe frostjaws protect their lands, but their leaders are allowed to" +
				"\ntake whatever they need.");
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
			player.GetModPlayer<FPPlayer>().compliance = true;
			player.pickSpeed += 0.20f;
			player.moveSpeed -= 0.20f;
			player.accRunSpeed -= 0.40f;

		}
	}
}
