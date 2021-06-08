using FPenumbra.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace FPenumbra.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class LivingRegenCooldown : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Living Regeneration Cooldown");
			Description.SetDefault("You're hurt; living regeneration boost disabled");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<FPPlayer>().livingregen = true;
		}
	}
}
