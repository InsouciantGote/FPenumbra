using Terraria;
using Terraria.ModLoader;

namespace FPenumbra.Buffs
{
	public class LiquidatorBoltsCooldown : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Liquidator Bolts Cooldown");
			Description.SetDefault("Liquidator Bolts on cooldown");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
		}
	}
}
