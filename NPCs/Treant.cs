using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.NPCs
{
	public class Treant : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults() {
			npc.width = 58;
			npc.height = 130;
			npc.damage = 55;
			npc.defense = 20;
			npc.lifeMax = 650;
            npc.rarity = 2;
			npc.value = 2000;
            npc.HitSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/TreantHurt");
            npc.DeathSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/TreantDeath");
            npc.knockBackResist = 0f;
            npc.aiStyle = 3;
            aiType = NPCID.GoblinScout;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.TreantBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.5f);
            npc.damage = (int)(npc.damage * 0.8f);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            if (FPWorld.downedseedsofdeterrence == true)
			{ }
			return (!NPC.AnyNPCs(ModContent.NPCType<Treant>()) && FPWorld.downedseedsofdeterrence == true && spawnInfo.player.ZoneOverworldHeight && !spawnInfo.player.ZoneBeach && !spawnInfo.player.ZoneCorrupt && !spawnInfo.player.ZoneCrimson && !spawnInfo.player.ZoneDesert && !spawnInfo.player.ZoneGlowshroom && !spawnInfo.player.ZoneHoly && !spawnInfo.player.ZoneJungle && !spawnInfo.player.ZoneMeteor && !spawnInfo.player.ZoneOldOneArmy && !spawnInfo.player.ZoneSnow && Main.dayTime == true).ToInt() * 0.18f;
		}

        public override void AI()
        {
            npc.velocity.X = npc.velocity.X /= 1.05f;
        }

        public override void FindFrame(int frameHeight)
		{
			npc.spriteDirection = npc.direction;
			npc.frameCounter++;
			if (npc.frameCounter >= 7)
			{
                npc.frame.Y += frameHeight;
                npc.frameCounter = 0;
				if (npc.frame.Y >= Main.npcFrameCount[npc.type] * frameHeight)
				{
					npc.frame.Y = 0;
				}
			}
            if (npc.velocity.Y > 0.03f)
			{
                npc.frameCounter = 0;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 6; i++)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Grass, 2 * hitDirection, -2f);
                dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.t_LivingWood, 2 * hitDirection, -2f);
                if (Main.rand.NextBool(2))
                {
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].scale = 1.2f * npc.scale;
                }
                else
                {
                    Main.dust[dust].scale = 0.7f * npc.scale;
                }
            }
            Player player = Main.LocalPlayer;
            if (npc.life <= 0 && player.active)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TreantGore1"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TreantGore2"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TreantGore3"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TreantGore4"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TreantGore5"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TreantGore6"), npc.scale);
            }
        }

        public override void NPCLoot()
        {
            if (FPWorld.downedseedsofdeterrence == true)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.EnchantedWood>(), Main.rand.Next(10, 20));
                if (Main.rand.NextFloat() < .12)
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<Items.LivingCherry>());
                }
                if (Main.rand.NextFloat() < .12)
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<Items.MysticStarfruit>());
                }
                if (Main.rand.NextFloat() < .25)
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<Projectiles.Minions.LilTreants.LilTreantItem>());
                }
            }
        }
    }
}
