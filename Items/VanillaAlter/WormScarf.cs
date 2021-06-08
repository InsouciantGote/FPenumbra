using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.VanillaAlter
{
	public class WormScarf : GlobalItem
	{
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.WormScarf)
            {
                foreach (TooltipLine line1 in tooltips)
                {
                    if (line1.mod == "Terraria" && line1.Name == "Tooltip0")
                    {
                        line1.text = "Reduces damage taken by 15%";
                    }
                }
            }
        }
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
			if (item.type == ItemID.WormScarf)
			player.endurance -= 0.02f;	
		}
	}
}