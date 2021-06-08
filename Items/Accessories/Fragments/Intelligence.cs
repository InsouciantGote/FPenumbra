using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Accessories.Fragments
{
	public class Intelligence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fragment of Intelligence");
            Tooltip.SetDefault
                ("+5% magic damage based on your current mana" +
                "\n+2% minion damage based on your current mana" +
                "\nReduces half of your maximum mana" +
				"\nChtulhu's brain dwells within the grotesque lands of the crimson," +
				"\nwaiting for the right moment where it can unleash its vengeance.");
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
			player.magicDamage += player.statMana * 0.005f;
			player.minionDamage += player.statMana * 0.002f;
			player.statManaMax2 /= 2;
		}
	}
}
