using FPenumbra.Items.Accessories.Fragments;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FPenumbra.Items.VanillaAlter
{
    public class Summonnerf : GlobalItem
    {
        public override void HoldItem(Item item, Player player)
        {
            if (ModContent.GetInstance<FPenumbraConfig>().summonerfconfig == true)
            {
                if (item.melee == true || item.ranged == true || item.magic == true || item.thrown == true || item.summon == false || !item.summon == true)
                {
                    player.GetModPlayer<FPPlayer>().summonnerf = true;
                }
                else
                {
                    player.GetModPlayer<FPPlayer>().summonnerf = false;
                }
            }
        }
    }
}