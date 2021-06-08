using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.NPCs.PrototypeVile
{
    public class VileDrone : ModNPC
    {
        public int Timer0;
        public int Timer1;
        public int Timer2;
        public int Timer3;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 4;
            NPCID.Sets.TrailingMode[npc.type] = 3;
            NPCID.Sets.TrailCacheLength[npc.type] = 8;
        }
        public override void SetDefaults()
        {
            npc.value = 100;
            npc.lifeMax = 100;
            npc.damage = 35;
            npc.defense = 6;
            npc.knockBackResist = 0f;
            npc.width = 24;
            npc.height = 42;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.behindTiles = false;
            npc.npcSlots = 0.15f;
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
            {
                {
                    Player player = Main.LocalPlayer;
                    // Altered Crimera AI without dust
                    {
                        if (npc.target < 0 || npc.target == 255 || !Main.player[npc.target].dead)
                        {
                            npc.TargetClosest(true);
                        }
                        float num3 = 0.4f;
                        float num11 = 0.02f;
                        Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num17 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
                        float num18 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
                        num3 = 0.4f;
                        num17 = (int)(num17 / 8f) * 8;
                        num18 = (int)(num18 / 8f) * 8;
                        vector.X = (int)(vector.X / 8f) * 8;
                        vector.Y = (int)(vector.Y / 8f) * 8;
                        num17 -= vector.X;
                        num18 -= vector.Y;
                        float num19 = (float)Math.Sqrt(num17 * num17 + num18 * num18);
                        float num20 = num19;
                        npc.velocity.X += num17 * 0.001f;
                        npc.velocity.Y += num18 * 0.001f;
                        npc.rotation = (float)Math.Atan2(num18, num17) - 1.57f;
                        if (npc.velocity.X >= 14.1)
                        { npc.velocity.X = 14; }
                        if (npc.velocity.Y > 11.1)
                        { npc.velocity.Y = 11; }
                        if (npc.velocity.X <= -14.1)
                        { npc.velocity.X = -14; }
                        if (npc.velocity.Y < -11.1)
                        { npc.velocity.Y = -11; }
                        if (npc.collideX)
                        {
                            npc.velocity.X = npc.oldVelocity.X * (0f - num3);
                            if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
                            {
                                npc.velocity.X = 0.3f;
                            }
                            if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
                            {
                                npc.velocity.X = -0.3f;
                            }
                        }
                        if (npc.collideY)
                        {
                            npc.velocity.Y = npc.oldVelocity.Y * (0f - num3);
                            if (npc.direction == -1 && npc.velocity.Y > 0f && npc.velocity.Y < 2f)
                            {
                                npc.velocity.Y = 0.3f;
                            }
                            if (npc.direction == 1 && npc.velocity.Y < 0f && npc.velocity.Y > -2f)
                            {
                                npc.velocity.Y = -0.3f;
                            }
                            if (npc.velocity.Y < num18)
                            {
                                npc.velocity.Y += num11;
                            }
                            if (npc.velocity.Y > num18)
                            {
                                npc.velocity.Y -= num11;
                            }
                        }
                        {
                            if (Main.player[npc.target].dead)
                            {
                                Timer0++;
                                npc.TargetClosest(false);
                                npc.velocity.Y = -5f;
                                npc.rotation = npc.velocity.ToRotation() + MathHelper.ToRadians(-90);
                                if (Timer0 == 180)
                                {
                                    npc.active = false;
                                }
                                player.GetModPlayer<FPPlayer>().viledroneshoot = false;
                            }
                            else
                            {
                                Timer0--;
                                Timer0 = 0;
                            }
                        }
                    }
                }
            }
            Lighting.AddLight(npc.Center, ((255 - npc.alpha) * 0.5f) / 255f, ((255 - npc.alpha) * 0.1f) / 255f, ((255 - npc.alpha) * 0.5f) / 255f);
            if (NPC.AnyNPCs(ModContent.NPCType<NPCs.PrototypeVile.PrototypeVile>()))
            { 
                Timer3++;
                if (Timer3 == 1)
                {
                    if (!Main.expertMode)
                    {
                        npc.value = 0;
                        npc.damage = 50;
                        npc.life = 200;
                        npc.lifeMax = 200;
                    }
                    else
                    {
                        npc.value = 0;
                        npc.damage = 90;
                        npc.life = 300;
                        npc.lifeMax = 300;
                    }
                }
            {
                Timer1++;
                if (Timer1 <= 350 && Main.player[npc.target].active == true)
                    { Timer1 += Main.rand.Next(1, 12); }
                if (Timer1 >= 400 && Main.player[npc.target].active == true)
                {
                    npc.velocity.X *= 1.45f;
                }
                if (Timer1 == 425 && Main.player[npc.target].active == true)
                {
                    npc.velocity.X = 0;
                    npc.velocity.Y = 0;
                }
                if (Timer1 == 426 && Main.player[npc.target].active == true)
                {
                    npc.velocity = npc.oldVelocity;
                    Timer1 = 0;
            }


                if (Main.LocalPlayer.GetModPlayer<FPPlayer>().viledroneshoot == true)
                {
                        if (Main.expertMode)
                        {
                            Timer2++;
                            if (Timer2 <= 300 && Main.player[npc.target].active == true)
                            { Timer2 += Main.rand.Next(1, 10); }
                            if (Timer2 == 300 && Main.player[npc.target].active == true)
                            {
                                Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                            }
                            if (Timer2 >= 700 && Main.player[npc.target].active == true)
                            {
                                Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                Timer2 = 0;
                            }
                            else
                            {
                                Timer2++;
                                if (Timer2 <= 300 && Main.player[npc.target].active == true)
                                { Timer2 += Main.rand.Next(1, 10); }
                                if (Timer2 == 450 && Main.player[npc.target].active == true)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer2 == 900 && Main.player[npc.target].active == true)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    Timer2 = 0;
                                }
                            }
                        }
                    }
                }
            }
            if (Timer1 >= 400)
            {
                for (int i = 0; i < 2; i++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.VileEnergyDust>());
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[dust].scale = 1.5f * npc.scale;
                        Main.dust[dust].velocity = -npc.velocity / 20;
                    }
                    else
                    {
                        Main.dust[dust].scale = 0.8f * npc.scale;
                        Main.dust[dust].velocity = -npc.velocity / 20;
                    }
                }
            }
            if (Vector2.Distance(Main.LocalPlayer.Center, npc.Center) > 1)
            {
                npc.timeLeft = 10;
            }
            {
                if (Main.player[npc.target].dead == true)
                {
                    npc.velocity.Y -= 0.04f;
                    npc.rotation = npc.velocity.ToRotation() + MathHelper.ToRadians(-90);
                    if (npc.timeLeft > 180)
                    {
                        npc.timeLeft = 180;
                    }
                }
            };
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;
            if (npc.frameCounter >= 5)
            {
                npc.frame.Y += frameHeight;
                npc.frameCounter = 0;
                if (npc.frame.Y >= Main.npcFrameCount[npc.type] * frameHeight)
                {
                    npc.frame.Y = 0;
                }
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.VileScrap>(), hitDirection);
                if (Main.rand.NextBool(2))
                {
                    Main.dust[dust].scale = 0.8f * npc.scale;
                    Main.dust[dust].noGravity = false;
                }
                else
                {
                    Main.dust[dust].scale = 0.3f * npc.scale;
                    Main.dust[dust].noGravity = false;
                }
            }
            Player player = Main.LocalPlayer;
            if (npc.life <= 0 && player.active == true)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VileDroneGore1"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VileDroneGore2"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VileDroneGore3"), npc.scale);
            }
        }
        //Scrapped trail
        //public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        //{
        //    Vector2 drawOrigin = new Vector2(npc.frame.Width, npc.frame.Height) / 2f;
        //    if (Timer1 >= 200)
        //        for (int k = (npc.oldPos.Length / 7); k < npc.oldPos.Length; k++)
        //        {
        //            Vector2 drawPos = npc.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, npc.gfxOffY);
        //            Color color = npc.GetAlpha(drawColor) * ((float)(npc.oldPos.Length - k) / (3f * npc.oldPos.Length));
        //            spriteBatch.Draw(Main.npcTexture[npc.type], drawPos, npc.frame, color, npc.oldRot[k], drawOrigin, npc.scale, SpriteEffects.None, 0f);
        //        }
        //    return true;
        //}
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/PrototypeVile/VileDrone_Glowmask");
            spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, Color.White, npc.rotation, new Vector2(npc.frame.Width, npc.frame.Height) / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
    }
}
