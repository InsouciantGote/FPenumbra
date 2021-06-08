using FPenumbra.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace FPenumbra.Buffs
{
	public class Cryostasis : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Cryostasis");
			Description.SetDefault("Hold tight within the cold.");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.frozen = true;
			player.immune = true;
			player.immuneTime = 1;
			player.immuneNoBlink = true;
			player.GetModPlayer<FPPlayer>().stasiscooldown = true;
		}
	}
}
