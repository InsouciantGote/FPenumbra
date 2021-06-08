using Terraria;
using Terraria.ModLoader;

namespace FPenumbra.Buffs
{
	public class StasisCooldown : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Stasis Cooldown");
			Description.SetDefault("Stasis ability on cooldown");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
		}
	}
}
