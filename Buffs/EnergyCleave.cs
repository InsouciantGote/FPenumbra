using Terraria;
using Terraria.ModLoader;

namespace FPenumbra.Buffs
{
	public class EnergyCleave : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("EnergyCleave");
			Description.SetDefault("Purple energies are reacting within you");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
		}
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<FPPlayer>().energycleave = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<NPCs.FPNPC>().energycleave = true;
		}
	}
}
