using FPenumbra.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace FPenumbra.Buffs
{
	public class FrozenShield : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Frozen Shield");
			Description.SetDefault("The heart strengthens you from being hurt.");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.statDefense += 7;
			player.GetModPlayer<FPPlayer>().frozenheart = true;
		}
	}
}
