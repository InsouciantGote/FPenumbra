using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.NPCs
{
	public class DungeonGuardianHallucination : ModNPC
	{
		public int Timer;
        public override string Texture => "Terraria/NPC_" + NPCID.SkeletronHead;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dungeon Guardian");
		}

		public override void SetDefaults() {
			npc.CloneDefaults(NPCID.DungeonGuardian);
			npc.life = 1998;
			npc.friendly = false;
			npc.damage = 0;
			npc.defense = 9999;
			npc.immortal = true;
            npc.boss = false;
			npc.value = 0;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.knockBackResist = 0f;
            npc.aiStyle = 11;
			aiType = NPCID.DungeonGuardian;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            Player player = Main.LocalPlayer;
            if (player.GetModPlayer<FPPlayer>().resistance == true)
			{ }
			return (!NPC.AnyNPCs(ModContent.NPCType<DungeonGuardianHallucination>()) && player.active == true).ToInt() * 0.01f;
		}

        public override void AI()
        {
			npc.width = -1;
			npc.height = -1;
			npc.damage = 0;
			Player player = Main.LocalPlayer;
			if (npc.alpha >= 250)
			{
				npc.active = false;
			}
			Timer++;
			if (Timer == 1)
            {
				Main.PlaySound(SoundID.ForceRoar, player.Center);
			};
			if (Timer >= 270 && npc.alpha <= 250)
			{
				npc.alpha += 10;
			}
		}

        public override void HitEffect(int hitDirection, double damage)
        {
			if (damage >= 1)
			{
				damage = 1;
			}
        }
    }
}
