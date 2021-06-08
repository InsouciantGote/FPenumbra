using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.NPCs.Frostjaw

{
    public class AlphaFrostjawBody : ModNPC
    {
        public int Timer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Alpha Frostjaw");
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 3350;
            npc.aiStyle = -1;
            npc.width = 50;
            npc.height = 62;
            npc.boss = false;
            npc.damage = 35;
            npc.defense = 125;
            npc.knockBackResist = 0.0f;
            npc.behindTiles = true;
            npc.noTileCollide = true;
            npc.netAlways = true;
            npc.noGravity = true;
            npc.friendly = false;
            npc.HitSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/FrostjawHit");
            npc.dontCountMe = true;
            npc.npcSlots = 0.5f;
            npc.buffImmune[BuffID.Frostburn] = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.85f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.8f);
        }

        public override bool PreAI()
        {   //Worm Body AI
            if (npc.ai[3] > 0)
                npc.realLife = (int)npc.ai[3];
            if (npc.target < 0 || npc.target == byte.MaxValue || Main.player[npc.target].dead)
                npc.TargetClosest(true);
            if (!NPC.AnyNPCs(ModContent.NPCType<NPCs.Frostjaw.AlphaFrostjawHead>()))
            {
                npc.active = false;
            }
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (!Main.npc[(int)npc.ai[1]].active)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                    NetMessage.SendData(MessageID.StrikeNPC, -1, -1, null, npc.whoAmI, -1f, 0.0f, 0.0f, 0, 0, 0);
                }
            }

            if (npc.ai[1] < (double)Main.npc.Length)
            {
                Vector2 npcCenter = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float dirX = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - npcCenter.X;
                float dirY = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - npcCenter.Y;
                npc.rotation = (float)Math.Atan2(dirY, dirX) + 1.57f;
                float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
                // We calculate a new, correct distance.
                float dist = (length - (float)npc.width) / length;
                float posX = dirX * dist;
                float posY = dirY * dist;
                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + posX;
                npc.position.Y = npc.position.Y + posY;
            }
            if (Main.player[npc.target].dead == true || npc.Distance(Main.LocalPlayer.Center) > 15000)
            {
                Timer++;
                if (Timer == 240)
                {
                    npc.active = false;
                }
            }
            Player player = Main.LocalPlayer;
            {
                if (player.ZoneSnow == false)
                {
                    int cooldown = Main.rand.Next(300, 600);
                    if (npc.ai[0]++ >= cooldown && Main.player[npc.target].active)
                    {
                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                        Projectile.NewProjectile(npc.Center, -velocity*3, mod.ProjectileType("AlphaFrostjawSpikeExpert"), npc.damage / 2, 3, Main.myPlayer, Main.myPlayer);
                        npc.ai[0] = 1;
                    }
                }
                if (Main.expertMode && player.active && player.ZoneSnow == true)
                {
                    int cooldown = Main.rand.Next(500, 2000);
                    if (npc.ai[0]++ >= cooldown && Main.player[npc.target].active)
                    {
                        if (npc.life < 3986.5)
                        {
                            Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                            Projectile.NewProjectile(npc.Center, -velocity, mod.ProjectileType("AlphaFrostjawSpikeExpert"), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                            npc.ai[0] = 1;
                        }
                    }
                }
                else
                {
                    int cooldown = Main.rand.Next(1200, 3400);
                    if (npc.ai[0]++ >= cooldown && Main.player[npc.target].active)
                    {
                        if (npc.life < 1695)
                        {
                            Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                            Projectile.NewProjectile(npc.Center, -velocity, mod.ProjectileType("AlphaFrostjawSpike"), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                            npc.ai[0] = 1;
                        }
                    }
                }
            }
            return false;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 6; i++)
            {
                int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.FrostjawDust>(), 2 * hitDirection, -2f);
                int dust2 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.FrostjawShards>(), hitDirection);
                if (Main.rand.NextBool(2))
                {
                    Main.dust[dust1].scale = 1.2f * npc.scale;
                    Main.dust[dust2].scale = 1.2f * npc.scale;
                    Main.dust[dust2].noGravity = false;
                }
                else
                {
                    Main.dust[dust1].scale = 0.8f * npc.scale;
                    Main.dust[dust2].scale = 0.8f * npc.scale;
                    Main.dust[dust2].noGravity = false;
                }
            }
            Player player = Main.LocalPlayer;
            if (npc.life <= 0 && player.active == true)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlphaFrostjawBodyGore1"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlphaFrostjawBodyGore2"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlphaFrostjawBodyGore3"), npc.scale);
            }
        }
        public override bool PreDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            Main.spriteBatch.Draw(texture, npc.Center - Main.screenPosition, new Rectangle?(), drawColor, npc.rotation, origin, npc.scale, SpriteEffects.None, 0);
            return false;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
    }
}