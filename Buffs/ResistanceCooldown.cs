using FPenumbra.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace FPenumbra.Buffs
{
	public class ResistanceCooldown : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Resistance Cooldown");
			Description.SetDefault("Resistance damage reduction ability on cooldown");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
		}
	}
}
