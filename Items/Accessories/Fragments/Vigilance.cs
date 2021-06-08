using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Accessories.Fragments
{
	public class Vigilance : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fragment of Vigilance");
			Tooltip.SetDefault
				("During the night, you gain night vision" +
				"\nDuring the day, you gain 9% increased damage instead" +
				"\nWhen the sun sets, you always get a feeling that something is watching you.");
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

			{
				if (Main.dayTime)
				{
					player.allDamage += 0.09f;
				}
				else
				{
					player.nightVision = true;
				}
			}
		}
	}
}
