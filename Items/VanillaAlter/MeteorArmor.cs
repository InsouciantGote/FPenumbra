using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.VanillaAlter
{
	public class MeteorArmor : GlobalItem
	{
		public static bool meteorset;
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.MeteorSuit)
			{
				Main.LocalPlayer.meleeDamage += 0.09f;
			}
			if (item.type == ItemID.MeteorLeggings)
			{
				Main.LocalPlayer.meleeDamage += 0.09f;
			}
		}
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if (item.type == ItemID.MeteorSuit)
			{
				foreach (TooltipLine line1 in tooltips)
				{
					if (line1.mod == "Terraria" && line1.Name == "Tooltip0")
					{
						line1.text = "9% increased melee and magic damage";
					}
				}
			}
			if (item.type == ItemID.MeteorLeggings)
			{
				foreach (TooltipLine line1 in tooltips)
				{
					if (line1.mod == "Terraria" && line1.Name == "Tooltip0")
					{
						line1.text = "9% increased melee and magic damage";
					}
				}
			}
		}
	}
}