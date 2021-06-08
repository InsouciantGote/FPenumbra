using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.NPCs.PrototypeVile
{
    public class VileBeacon : ModNPC
    {
        public int Timer;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 8;
        }
        public override void SetDefaults()
        {
            npc.value = 0;
            npc.lifeMax = 500;
            npc.damage = 0;
            npc.defense = 6;
            npc.knockBackResist = 0f;
            npc.width = 24;
            npc.height = 42;
            npc.lavaImmune = false;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.behindTiles = true;
            npc.npcSlots = 1f;
            npc.aiStyle = -1;
            npc.buffImmune[BuffID.Ichor] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.buffImmune[BuffID.Bleeding] = true;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Venom] = true;
            npc.buffImmune[BuffID.Frozen] = true;
            npc.buffImmune[BuffID.Slow] = true;
            npc.buffImmune[BuffID.Burning] = true;
            npc.buffImmune[BuffID.ShadowFlame] = true;
            npc.buffImmune[BuffID.Weak] = true;
            npc.buffImmune[BuffID.Confused] = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.5f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.5f);
        }

        public override void AI()
        {
            Lighting.AddLight(npc.Center, ((255 - npc.alpha) * 0.5f) / 255f, ((255 - npc.alpha) * 0.1f) / 255f, ((255 - npc.alpha) * 0.5f) / 255f);
            Timer++;
            if (Timer == 200)
            {
                Vector2 velocity = new Vector2(Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(2.5f, -2.5f));
                Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                Timer = 0;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;
            if (npc.frameCounter >= 9)
            {
                npc.frame.Y += frameHeight;
                npc.frameCounter = 0;
                if (npc.frame.Y >= Main.npcFrameCount[npc.type] * frameHeight)
                {
                    npc.frame.Y = 0;
                }
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            {
                return (spawnInfo.player.ZoneCrimson && spawnInfo.player.ZoneOverworldHeight | spawnInfo.player.ZoneCorrupt && spawnInfo.player.ZoneOverworldHeight).ToInt() * 0.3f;
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.VileScrap>(), hitDirection);
                if (Main.rand.NextBool(2))
                {
                    Main.dust[dust1].scale = 1.1f * npc.scale;
                    Main.dust[dust1].noGravity = false;
                }
                else
                {
                    Main.dust[dust1].scale = 0.4f * npc.scale;
                    Main.dust[dust1].noGravity = false;
                }
                int dust2 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.VileEnergyDust>(), hitDirection);
                if (Main.rand.NextBool(2))
                {
                    Main.dust[dust2].scale = 1.2f * npc.scale;
                }
                else
                {
                    Main.dust[dust2].scale = 0.7f * npc.scale;
                }
            }
            Player player = Main.LocalPlayer;
            if (npc.life <= 0 && player.active == true)
            {
                for (int i = 0; i < 20; i++)
                {
                    int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.VileScrap>(), hitDirection);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[dust1].scale = 1f * npc.scale;
                        Main.dust[dust1].noGravity = false;
                    }
                    else
                    {
                        Main.dust[dust1].scale = 0.5f * npc.scale;
                        Main.dust[dust1].noGravity = false;
                    }
                }
            }
            if (npc.life <= 0 && player.active == true)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VileBeaconGore1"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VileBeaconGore2"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VileBeaconGore3"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VileBeaconGore4"), npc.scale);
            }
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ModContent.ItemType<Items.PrototypeVile.Protocore>());
            if (Main.rand.NextFloat() < .15)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Weapons.Protoblade>());
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/PrototypeVile/VileBeacon_Glowmask");
            spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, Color.White, npc.rotation, new Vector2(npc.frame.Width, npc.frame.Height + 8) / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
    }
}
