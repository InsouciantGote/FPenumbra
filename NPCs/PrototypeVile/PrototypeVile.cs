using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace FPenumbra.NPCs.PrototypeVile
{
    [AutoloadBossHead]
    public class PrototypeVile : ModNPC
    {
        public int Timer0;
        public int Timer1;
        public int Timer2;
        public int Timer3;
        public int Timer4;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 6;
            DisplayName.SetDefault("V.I.L.E.");
            NPCID.Sets.TrailingMode[npc.type] = 3;
            NPCID.Sets.TrailCacheLength[npc.type] = 8;
        }
        public override void SetDefaults()
        {
            npc.value = 50000;
            npc.lifeMax = 6700;
            npc.boss = true;
            npc.damage = 75;
            npc.defense = 16;
            npc.knockBackResist = 0f;
            npc.width = 80;
            npc.height = 162;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 5f;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.behindTiles = false;
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
            music = MusicID.Boss3;
            bossBag = ModContent.ItemType<Items.PrototypeVile.PrototypeVileBag>();
        }

        public override void AI()
        {
            {
                Player player = Main.LocalPlayer;
                // Altered Crimera AI without dust
                {
                    if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].active)
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
                    float num21 = 3f;
                    float num22 = 1.8f;
                    npc.velocity.X += num17 * 0.001f;
                    npc.velocity.Y += num18 * 0.001f;
                    npc.rotation = (float)Math.Atan2(num18, num17) - 1.57f;
                    if (npc.life > 5360)
                    {
                        if (npc.velocity.X >= 7.1)
                        { npc.velocity.X = 7; }
                        if (npc.velocity.Y > 7.1)
                        { npc.velocity.Y = 7; }
                        if (npc.velocity.X <= -7.1)
                        { npc.velocity.X = -7; }
                        if (npc.velocity.Y < -7.1)
                        { npc.velocity.Y = -7; }
                    }
                    if (npc.life < 5360)
                    {
                        if (npc.velocity.X >= 11.1)
                        { npc.velocity.X = 11; }
                        if (npc.velocity.Y > 11.1)
                        { npc.velocity.Y = 11; }
                        if (npc.velocity.X <= -11.1)
                        { npc.velocity.X = -11; }
                        if (npc.velocity.Y < -11.1)
                        { npc.velocity.Y = -11; }
                    }
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
                    if (Timer1 <= 77 || Timer3 >= 825 && Timer3 <= 885 || Timer4 >= 425 && Timer4 <= 485 || Timer4 >= 825 && Timer4 <= 885)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            int dust = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.VileEnergyDust>());
                            if (Main.rand.NextBool(2))
                            {
                                Main.dust[dust].scale = 1.9f * npc.scale;
                                Main.dust[dust].velocity = -npc.velocity / 20;
                            }
                            else
                            {
                                Main.dust[dust].scale = 0.7f * npc.scale;
                                Main.dust[dust].velocity = -npc.velocity / 20;
                            }
                        }
                    }
                    if (Vector2.Distance(Main.LocalPlayer.Center, npc.Center) > 1)
                    {
                        npc.timeLeft = 10;
                    }
                    {
                        if (Main.player[npc.target].dead == true || npc.Distance(Main.LocalPlayer.Center) > 15000)
                        {
                            Timer0++;
                            npc.velocity.Y = -5f;
                            npc.rotation = npc.velocity.ToRotation() + MathHelper.ToRadians(-90);
                            if (Timer0 == 240)
                            {
                                npc.active = false;
                            }
                        }
                        else
                        {
                            Timer0--;
                            Timer0 = 0;
                        }
                    }
                    if (npc.active == false)
                    {
                        player.GetModPlayer<FPPlayer>().viledroneshoot = false;
                    }
                    Lighting.AddLight(npc.Center, ((255 - npc.alpha) * 0.5f) / 255f, ((255 - npc.alpha) * 0.1f) / 255f, ((255 - npc.alpha) * 0.5f) / 255f);
                    {
                        if (!Main.expertMode)
                        {
                            {
                                if (npc.life > 3350)
                                {
                                    Timer1++;
                                    if (Timer1 == 1 && Main.player[npc.target].active)
                                    {
                                        Timer1 = 112;
                                    }
                                    if (Timer1 == 60 && Main.player[npc.target].active == true)
                                    {
                                        npc.velocity.X = num21;
                                        npc.velocity.Y = num22;
                                    }
                                    if (Timer1 >= 75 && Timer1 <= 112 && Main.player[npc.target].active == true)
                                    {
                                        npc.velocity.X *= 0f;
                                        npc.velocity.Y *= 0f;
                                    }
                                    if (Timer1 == 82 && Main.player[npc.target].active)
                                    {
                                        Projectile.NewProjectile(npc.Center, new Vector2(2, 2), ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                        Projectile.NewProjectile(npc.Center, new Vector2(-2, 2), ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                        Projectile.NewProjectile(npc.Center, new Vector2(2, -2), ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                        Projectile.NewProjectile(npc.Center, new Vector2(-2, -2), ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (Timer1 == 402 && Main.player[npc.target].active)
                                    {
                                        Vector2 velocity = new Vector2(Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(2.5f, -2.5f));
                                        Projectile.NewProjectile(npc.Center, velocity * 2, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (Timer1 == 602 && Main.player[npc.target].active)
                                    {
                                        Vector2 velocity = new Vector2(Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(2.5f, -2.5f));
                                        Projectile.NewProjectile(npc.Center, velocity * 2, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                    }

                                    if (Timer1 == 802 && Main.player[npc.target].active)
                                    {
                                        Main.PlaySound(SoundID.ForceRoar, npc.position, 0);
                                        Timer1 = 2;
                                    }
                                }
                            }
                            if (npc.life < 5360 && npc.life > 3350)
                            {
                                player.GetModPlayer<FPPlayer>().viledroneshoot = true;
                                Timer2++;
                                if (Timer2 == 125 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer2 == 175 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer2 == 250 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer2 == 300 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    Timer2 = 0;
                                }
                            }
                            if (npc.life < 3350)
                            {
                                player.GetModPlayer<FPPlayer>().viledroneshoot = true;
                                Timer3++;
                                if (Timer3 == 1 && Main.player[npc.target].active)
                                {
                                    npc.velocity = npc.oldVelocity;
                                    Timer3 = 942;
                                }
                                if (Timer3 == 130 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 == 190 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 == 215 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(2.5f, -2.5f));
                                    Projectile.NewProjectile(npc.Center, velocity * 2, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 == 350 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(2.5f, -2.5f));
                                    Projectile.NewProjectile(npc.Center, velocity * 2, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 == 300 && Main.player[npc.target].active)
                                {
                                    if (WorldGen.crimson == true)
                                    {
                                        float numberProjectiles = 3;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(30);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.3f, ModContent.ProjectileType<Projectiles.PrototypeVile.IchorLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (WorldGen.crimson == false)
                                    {
                                        float numberProjectiles = 3;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.3f, ModContent.ProjectileType<Projectiles.PrototypeVile.CursedLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                }
                                if (Timer3 == 430 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 == 490 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 == 600 && Main.player[npc.target].active)
                                {
                                    if (WorldGen.crimson == true)
                                    {
                                        float numberProjectiles = 5;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.3f, ModContent.ProjectileType<Projectiles.PrototypeVile.IchorLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (WorldGen.crimson == false)
                                    {
                                        float numberProjectiles = 5;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.3f, ModContent.ProjectileType<Projectiles.PrototypeVile.CursedLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                }
                                if (Timer3 == 700 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(2.5f, -2.5f));
                                    Projectile.NewProjectile(npc.Center, velocity * 2, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 == 750 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(2.5f, -2.5f));
                                    Projectile.NewProjectile(npc.Center, velocity * 2, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 >= 800 && Timer3 <= 825 && Main.player[npc.target].active == true)
                                {
                                    npc.velocity.Y = -30;
                                    npc.rotation = MathHelper.ToRadians(180);
                                }
                                if (Timer3 >= 825 && Timer3 <= 885 && Main.player[npc.target].active == true)
                                {
                                    npc.velocity.X *= 3.9f;
                                    npc.velocity.Y = 0;
                                    npc.rotation = (float)Math.Atan2(num18, num17) - 1.57f;
                                }
                                if (Timer3 == 825 && Main.player[npc.target].active == true)
                                {
                                    Main.PlaySound(SoundID.ForceRoar, npc.position, 0);
                                }
                                if (Timer3 == 830 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 835 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 840 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 845 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 850 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 855 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 860 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 865 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 870 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 875 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 880 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 885 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                    npc.velocity = npc.oldVelocity;
                                }
                                if (Timer3 == 950)
                                {
                                    float numberProjectiles = 6;
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    float rotation = MathHelper.ToRadians(60);
                                    for (int i = 0; i < numberProjectiles; i++)
                                        Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 2.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 >= 943 && Timer1 <= 980 && Main.player[npc.target].active == true)
                                {
                                    npc.velocity.X *= 0f;
                                    npc.velocity.Y *= 0f;
                                }
                                if (Timer3 == 980 && Main.player[npc.target].active == true)
                                {
                                    Timer3 = 2;
                                }
                            }
                        }
                        if (Main.expertMode)
                        {
                            {
                                if (npc.life > 5360)
                                {
                                    Timer1++;
                                    if (Timer1 == 1 && Main.player[npc.target].active)
                                    {
                                        NPC.NewNPC((int)npc.position.X + 50, (int)npc.position.Y + 110, mod.NPCType("VileDrone"));
                                        NPC.NewNPC((int)npc.position.X + 50, (int)npc.position.Y + 110, mod.NPCType("VileDrone"));
                                        NPC.NewNPC((int)npc.position.X + 50, (int)npc.position.Y + 110, mod.NPCType("VileDrone"));
                                        Timer1 = 112;
                                    }
                                    if (Timer1 <= 60 && Main.player[npc.target].active == true)
                                    {
                                        npc.velocity.X *= num21;
                                        npc.velocity.Y *= num22;
                                    }
                                    if (Timer1 >= 75 && Timer1 <= 112 && Main.player[npc.target].active == true)
                                    {
                                        npc.velocity.X *= 0f;
                                        npc.velocity.Y *= 0f;
                                    }
                                    if (Timer1 == 82 && Main.player[npc.target].active)
                                    {
                                        Projectile.NewProjectile(npc.Center, new Vector2(2, 2), ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                        Projectile.NewProjectile(npc.Center, new Vector2(-2, 2), ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                        Projectile.NewProjectile(npc.Center, new Vector2(2, -2), ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                        Projectile.NewProjectile(npc.Center, new Vector2(-2, -2), ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (Timer1 == 202 && Main.player[npc.target].active)
                                    {
                                        Vector2 velocity = new Vector2(Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(2.5f, -2.5f));
                                        Projectile.NewProjectile(npc.Center, velocity * 2, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (Timer1 == 402 && Main.player[npc.target].active)
                                    {
                                        Vector2 velocity = new Vector2(Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(2.5f, -2.5f));
                                        Projectile.NewProjectile(npc.Center, velocity * 2, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (Timer1 == 602 && Main.player[npc.target].active)
                                    {
                                        Vector2 velocity = new Vector2(Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(2.5f, -2.5f));
                                        Projectile.NewProjectile(npc.Center, velocity * 2, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                    }

                                    if (Timer1 == 802 && Main.player[npc.target].active)
                                    {
                                        Main.PlaySound(SoundID.ForceRoar, npc.position, 0);
                                        Timer1 = 2;
                                    }
                                }
                            }
                            if (npc.life < 8576 && npc.life > 5360)
                            {
                                player.GetModPlayer<FPPlayer>().viledroneshoot = true;
                                Timer2++;
                                if (Timer2 == 125 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer2 == 175 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer2 == 250 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer2 == 275 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer2 == 300 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    Timer2 = 0;
                                }
                            }
                            if (npc.life < 5360 && npc.life > 2680)
                            {
                                player.GetModPlayer<FPPlayer>().viledroneshoot = true;
                                Timer3++;
                                if (Timer3 == 1 && Main.player[npc.target].active)
                                {
                                    npc.velocity = npc.oldVelocity;
                                    Timer3 = 942;
                                }
                                if (Timer3 == 130 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 == 190 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 == 300 && Main.player[npc.target].active)
                                {
                                    if (WorldGen.crimson == true)
                                    { 
                                    float numberProjectiles = 5;
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    float rotation = MathHelper.ToRadians(30);
                                    for (int i = 0; i < numberProjectiles; i++)
                                    Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.IchorLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (WorldGen.crimson == false)
                                    {
                                        float numberProjectiles = 5;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                    Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.CursedLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                }
                                if (Timer3 == 350 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(2.5f, -2.5f));
                                    Projectile.NewProjectile(npc.Center, velocity * 2, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 == 430 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 == 490 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 == 600 && Main.player[npc.target].active)
                                {
                                    if (WorldGen.crimson == true)
                                    {
                                        float numberProjectiles = 5;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.IchorLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (WorldGen.crimson == false)
                                    {
                                        float numberProjectiles = 5;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.CursedLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                }
                                if (Timer3 == 700 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(2.5f, -2.5f));
                                    Projectile.NewProjectile(npc.Center, velocity * 2, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 == 750 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(Main.rand.NextFloat(-2.5f, 2.5f), Main.rand.NextFloat(2.5f, -2.5f));
                                    Projectile.NewProjectile(npc.Center, velocity * 2, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 >= 800 && Timer3 <= 825 && Main.player[npc.target].active == true)
                                {
                                    npc.velocity.Y = -30;
                                    npc.rotation = MathHelper.ToRadians(180);
                                }
                                if (Timer3 >= 825 && Timer3 <= 885 && Main.player[npc.target].active == true)
                                {
                                    npc.velocity.X *= 3.5f;
                                    npc.velocity.Y = 0;
                                    npc.rotation = (float)Math.Atan2(num18, num17) - 1.57f;
                                }
                                if (Timer3 == 825 && Main.player[npc.target].active == true)
                                {
                                    Main.PlaySound(SoundID.ForceRoar, npc.position, 0);
                                }
                                if (Timer3 == 830 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 835 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 840 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 845 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 850 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 855 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 860 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 865 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 870 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 875 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 880 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 885 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer3 == 950)
                                {
                                    float numberProjectiles = 8;
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    float rotation = MathHelper.ToRadians(60);
                                    for (int i = 0; i < numberProjectiles; i++)
                                        Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 2.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileDroneSpawner>(), 0, 0, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer3 >= 943 && Timer3 <= 980 && Main.player[npc.target].active == true)
                                {
                                    npc.velocity.X *= 0f;
                                    npc.velocity.Y *= 0f;
                                }
                                if (Timer3 == 980 && Main.player[npc.target].active == true)
                                {
                                    Timer3 = 2;
                                }
                            }
                            if (npc.life < 2680)
                            {
                                player.GetModPlayer<FPPlayer>().viledroneshoot = true;
                                Timer4++;
                                if (Timer4 == 4 && Main.player[npc.target].active)
                                {
                                    npc.velocity = npc.oldVelocity;
                                }
                                if (Timer4 == 100 && Main.player[npc.target].active)
                                {
                                    if (WorldGen.crimson == true)
                                    {
                                        float numberProjectiles = 5;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.IchorLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (WorldGen.crimson == false)
                                    {
                                        float numberProjectiles = 5;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.CursedLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                }
                                if (Timer4 == 150 && Main.player[npc.target].active)
                                {
                                    if (WorldGen.crimson == true)
                                    {
                                        float numberProjectiles = 4;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(30);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.IchorLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (WorldGen.crimson == false)
                                    {
                                        float numberProjectiles = 4;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.CursedLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                }
                                if (Timer4 == 200 && Main.player[npc.target].active)
                                {
                                    if (WorldGen.crimson == true)
                                    {
                                        float numberProjectiles = 5;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.IchorLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (WorldGen.crimson == false)
                                    {
                                        float numberProjectiles = 5;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.CursedLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                }
                                if (Timer4 == 250 && Main.player[npc.target].active)
                                {
                                    if (WorldGen.crimson == true)
                                    {
                                        float numberProjectiles = 4;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(30);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.IchorLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (WorldGen.crimson == false)
                                    {
                                        float numberProjectiles = 4;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.CursedLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                }
                                if (Timer4 == 300 && Main.player[npc.target].active)
                                {
                                    if (WorldGen.crimson == true)
                                    {
                                        float numberProjectiles = 5;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.IchorLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                    if (WorldGen.crimson == false)
                                    {
                                        float numberProjectiles = 5;
                                        Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                        float rotation = MathHelper.ToRadians(27);
                                        for (int i = 0; i < numberProjectiles; i++)
                                            Projectile.NewProjectile(npc.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 4.8f, ModContent.ProjectileType<Projectiles.PrototypeVile.CursedLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                    }
                                }

                                if (Timer4 >= 400 && Timer4 <= 425 && Main.player[npc.target].active == true)
                                {
                                    npc.velocity.Y = -30;
                                    npc.rotation = MathHelper.ToRadians(180);
                                }
                                if (Timer4 >= 425 && Timer4 <= 485 && Main.player[npc.target].active == true)
                                {
                                    npc.velocity.X *= 3.6f;
                                    npc.velocity.Y = 0;
                                    npc.rotation = (float)Math.Atan2(num18, num17) - 1.57f;
                                }
                                if (Timer4 == 425 && Main.player[npc.target].active == true)
                                {
                                    Main.PlaySound(SoundID.ForceRoar, npc.position, 0);
                                }
                                if (Timer4 == 430 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 435 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 440 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 445 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 450 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 455 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 460 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 465 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 470 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 475 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 480 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 485 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                    npc.velocity = npc.oldVelocity;
                                }
                                if (Timer4 == 500 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer4 == 530 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer4 == 560 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer4 == 590 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer4 == 670 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer4 == 700 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer4 == 730 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer4 == 760 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer4 == 790 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center);
                                    Projectile.NewProjectile(npc.Center, -velocity * 4.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.VileLaser>(), npc.damage / 4, 3, Main.myPlayer, Main.myPlayer);
                                }
                                if (Timer4 >= 800 && Timer4 <= 825 && Main.player[npc.target].active == true)
                                {
                                    npc.velocity.Y = -30;
                                    npc.rotation = MathHelper.ToRadians(180);
                                }
                                if (Timer4 >= 825 && Timer4 <= 885 && Main.player[npc.target].active == true)
                                {
                                    npc.velocity.X *= 3.6f;
                                    npc.velocity.Y = 0;
                                    npc.rotation = (float)Math.Atan2(num18, num17) - 1.57f;
                                }
                                if (Timer4 == 825 && Main.player[npc.target].active == true)
                                {
                                    Main.PlaySound(SoundID.ForceRoar, npc.position, 0);
                                }
                                if (Timer4 == 830 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 835 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 840 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 845 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 850 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 855 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 860 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 865 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 870 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 875 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 880 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                }
                                if (Timer4 == 885 && Main.player[npc.target].active)
                                {
                                    Vector2 velocity = new Vector2(0);
                                    Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<Projectiles.PrototypeVile.VileBomb>(), npc.damage / 3, 6);
                                    npc.velocity = npc.oldVelocity;
                                    Timer4 = 0;
                                }
                            }
                        }
                    }
                }
            }
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.80f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.8f);
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;
            if (npc.frameCounter >= 7)
            {
                npc.frame.Y += frameHeight;
                npc.frameCounter = 0;
                if (npc.frame.Y >= 5 * frameHeight)
                {
                    npc.frame.Y = 1;
                }
            }
            if (Timer3 >= 800 && Timer3 <= 825 || Timer4 >= 400 && Timer4 <= 425 || Timer4 >= 800 && Timer4 <= 825)
            {
                npc.frameCounter = 0;
                npc.frame.Y = 6;
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(npc.position, npc.width/2, npc.height, ModContent.DustType<Dusts.VileScrap>(), hitDirection);
                if (Main.rand.NextBool(2))
                {
                    Main.dust[dust].scale = 1.1f * npc.scale;
                    Main.dust[dust].noGravity = false;
                }
                else
                {
                    Main.dust[dust].scale = 0.7f * npc.scale;
                    Main.dust[dust].noGravity = false;
                }
            }
            Player player = Main.LocalPlayer;
            if (npc.life <= 0 && player.active == true)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrototypeVileGore1"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrototypeVileGore2"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrototypeVileGore3"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrototypeVileGore4"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrototypeVileGore5"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrototypeVileGore6"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrototypeVileGore7"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrototypeVileGore8"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PrototypeVileGore9"), npc.scale);
            }
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/PrototypeVile/PrototypeVile_Glowmask");
            spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, Color.White, npc.rotation, new Vector2(npc.frame.Width, npc.frame.Height) / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
        public override void NPCLoot()
        {
            if (!FPWorld.downedPrototypeVile)
            {
                FPWorld.downedPrototypeVile = true;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData);
                }
            }
            if (Main.rand.NextFloat() < .10)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Placeable.PrototypeVileTrophy>());
            }
            Item.NewItem(npc.getRect(), ItemID.LesserHealingPotion, Main.rand.Next(5, 15));
            if (Main.rand.NextFloat() < .1429)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.PrototypeVile.PrototypeVileMask>());
            }
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.PrototypeVile.LiquidatorScrap>(), Main.rand.Next(18, 30));
                var dropChooser1 = new WeightedRandom<int>();
                dropChooser1.Add(ModContent.ItemType<Items.PrototypeVile.EnergyCleaver>());
                dropChooser1.Add(ModContent.ItemType<Items.PrototypeVile.LiquidatorBow>());
                dropChooser1.Add(ModContent.ItemType<Items.PrototypeVile.Protoblaster>());
                dropChooser1.Add(ModContent.ItemType<Projectiles.Minions.VileDrones.VileDroneItem>());
                int choice1 = dropChooser1;
                Item.NewItem(npc.getRect(), choice1);
                var dropChooser2 = new WeightedRandom<int>();
                dropChooser2.Add(ModContent.ItemType<Items.PrototypeVile.EnergyCleaver>());
                dropChooser2.Add(ModContent.ItemType<Items.PrototypeVile.LiquidatorBow>());
                dropChooser2.Add(ModContent.ItemType<Items.PrototypeVile.Protoblaster>());
                dropChooser2.Add(ModContent.ItemType<Projectiles.Minions.VileDrones.VileDroneItem>());
                int choice2 = dropChooser2;
                Item.NewItem(npc.getRect(), choice2);
            }
        }
    }
}
