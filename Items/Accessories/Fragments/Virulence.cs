using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Accessories.Fragments
{
	public class Virulence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fragment of Virulence");
			Tooltip.SetDefault
				("+12% critical chance" +
				"\nWhen hurt, you get cursed for 2.5 seconds" +
				"\nThese mechanical monstrosities appear to be scanning the lands. Their origins are" +
				"\nunknown as their energies appear to be otherworldly.");
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
			player.meleeCrit += 12;
			player.rangedCrit += 12;
			player.magicCrit += 12;
			player.thrownCrit += 12;
			player.GetModPlayer<FPPlayer>().virulencecurse = true;
		}
	}
}
