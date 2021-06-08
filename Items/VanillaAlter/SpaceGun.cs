using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.VanillaAlter
{
	public class SpaceGun : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (ModContent.GetInstance<FPenumbraConfig>().spacegunnerf == true)
			{
				if (item.type == ItemID.SpaceGun)
				{
					item.damage -= 8;
					item.useTime = 12;
					item.useAnimation = 12;
				}
			}
		}
	}
}