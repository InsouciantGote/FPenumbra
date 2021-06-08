using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace FPenumbra.NPCs.Frostjaw
{
    [AutoloadBossHead]
    public class AlphaFrostjawHead : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Alpha Frostjaw");
        }
        public override void SetDefaults()
        {
            npc.value = 20000;
            npc.lifeMax = 3350;
            npc.boss = true;
            npc.damage = 35;
            npc.defense = 2;
            npc.knockBackResist = 0f;
            npc.width = 66;
            npc.height = 60;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/FrostjawHit");
            npc.DeathSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/AlphaFrostjawDeath");
            npc.behindTiles = true;
            Main.npcFrameCount[npc.type] = 1;
            npc.npcSlots = 1;
            npc.netAlways = true;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.buffImmune[BuffID.Frozen] = true;
            music = MusicID.Boss1;
            bossBag = ModContent.ItemType<Items.Frostjaw.AlphaFrostjawBag>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.85f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.8f);
        }
        public override bool PreAI()
        {   //Worm Head AI
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (npc.ai[0] == 0)
                {
                    npc.realLife = npc.whoAmI;
                    int latestNPC = npc.whoAmI;
                    int randomWormLength = 20;
                    for (int i = 0; i < randomWormLength; ++i)
                    {
                        latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AlphaFrostjawBody"), npc.whoAmI, 0, latestNPC);
                        Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                        Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;
                    }
                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AlphaFrostjawTail"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;
                    npc.ai[0] = 1;
                    npc.netUpdate = true;
                }
            }
            int minTilePosX = (int)(npc.position.X / 16.0) - 1;
            int maxTilePosX = (int)((npc.position.X + npc.width) / 16.0) + 2;
            int minTilePosY = (int)(npc.position.Y / 16.0) - 1;
            int maxTilePosY = (int)((npc.position.Y + npc.height) / 16.0) + 2;
            if (minTilePosX < 0)
                minTilePosX = 0;
            if (maxTilePosX > Main.maxTilesX)
                maxTilePosX = Main.maxTilesX;
            if (minTilePosY < 0)
                minTilePosY = 0;
            if (maxTilePosY > Main.maxTilesY)
                maxTilePosY = Main.maxTilesY;

            bool collision = false;
            for (int i = minTilePosX; i < maxTilePosX; ++i)
            {
                for (int j = minTilePosY; j < maxTilePosY; ++j)
                {
                    if (Main.tile[i, j] != null && (Main.tile[i, j].nactive() && (Main.tileSolid[(int)Main.tile[i, j].type] || Main.tileSolidTop[(int)Main.tile[i, j].type] && (int)Main.tile[i, j].frameY == 0) || (int)Main.tile[i, j].liquid > 360))
                    {
                        Vector2 vector2;
                        vector2.X = (float)(i * 16);
                        vector2.Y = (float)(j * 16);
                        if (npc.position.X + npc.width > vector2.X && npc.position.X < vector2.X + 16.0 && (npc.position.Y + npc.height > (double)vector2.Y && npc.position.Y < vector2.Y + 16.0))
                        {
                            collision = true;
                            if (Main.rand.Next(400) == 0 && Main.tile[i, j].nactive())
                                WorldGen.KillTile(i, j, true, true, false);
                        }
                    }
                }
            }
            if (!collision)
            {
                Rectangle rectangle1 = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
                int maxDistance = 5000;
                bool playerCollision = true;
                for (int index = 0; index < 255; ++index)
                {
                    if (Main.player[index].active)
                    {
                        Rectangle rectangle2 = new Rectangle((int)Main.player[index].position.X - maxDistance, (int)Main.player[index].position.Y - maxDistance, maxDistance * 10, maxDistance * 10);
                        if (rectangle1.Intersects(rectangle2))
                        {
                            playerCollision = false;
                            break;
                        }
                    }
                }
                if (playerCollision)
                    collision = true;
            }

            float speed = 10;
            float acceleration = 0.12f;

            Vector2 npcCenter = new Vector2(npc.position.X + npc.width * 0.9f, npc.position.Y + npc.height * 0.9f);
            float targetXPos = Main.player[npc.target].position.X + (Main.player[npc.target].width / 2);
            float targetYPos = Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2);

            float targetRoundedPosX = (float)((int)(targetXPos / 16.0) * 16);
            float targetRoundedPosY = (float)((int)(targetYPos / 16.0) * 16);
            npcCenter.X = (float)((int)(npcCenter.X / 16.0) * 16);
            npcCenter.Y = (float)((int)(npcCenter.Y / 16.0) * 16);
            float dirX = targetRoundedPosX - npcCenter.X;
            float dirY = targetRoundedPosY - npcCenter.Y;

            float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
            if (!collision)
            {
                npc.TargetClosest(true);
                npc.velocity.Y = npc.velocity.Y + 0.11f;
                if (npc.velocity.Y > speed)
                    npc.velocity.Y = speed;
                if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < speed * 0.4)
                {
                    if (npc.velocity.X < 0.0)
                        npc.velocity.X = npc.velocity.X - acceleration * 1.1f;
                    else
                        npc.velocity.X = npc.velocity.X + acceleration * 1.1f;
                }
                else if (npc.velocity.Y == speed)
                {
                    if (npc.velocity.X < dirX)
                        npc.velocity.X = npc.velocity.X + acceleration;
                    else if (npc.velocity.X > dirX)
                        npc.velocity.X = npc.velocity.X - acceleration;
                }
                else if (npc.velocity.Y > 4.0)
                {
                    if (npc.velocity.X < 0.0)
                        npc.velocity.X = npc.velocity.X + acceleration * 0.9f;
                    else
                        npc.velocity.X = npc.velocity.X - acceleration * 0.9f;
                }
            }
            else
            {
                if (npc.soundDelay == 0)
                {
                    float num1 = length / 40f;
                    if (num1 < 10.0)
                        num1 = 10f;
                    if (num1 > 20.0)
                        num1 = 20f;
                    npc.soundDelay = (int)num1;
                }
                float absDirX = Math.Abs(dirX);
                float absDirY = Math.Abs(dirY);
                float newSpeed = speed / length;
                dirX = dirX * newSpeed;
                dirY = dirY * newSpeed;
                if (npc.velocity.X > 0.0 && dirX > 0.0 || npc.velocity.X < 0.0 && dirX < 0.0 || (npc.velocity.Y > 0.0 && dirY > 0.0 || npc.velocity.Y < 0.0 && dirY < 0.0))
                {
                    if (npc.velocity.X < dirX)
                        npc.velocity.X = npc.velocity.X + acceleration;
                    else if (npc.velocity.X > dirX)
                        npc.velocity.X = npc.velocity.X - acceleration;
                    if (npc.velocity.Y < dirY)
                        npc.velocity.Y = npc.velocity.Y + acceleration;
                    else if (npc.velocity.Y > dirY)
                        npc.velocity.Y = npc.velocity.Y - acceleration;
                    if (Math.Abs(dirY) < speed * 0.2 && (npc.velocity.X > 0.0 && dirX < 0.0 || npc.velocity.X < 0.0 && dirX > 0.0))
                    {
                        if (npc.velocity.Y > 0.0)
                            npc.velocity.Y = npc.velocity.Y + acceleration * 2f;
                        else
                            npc.velocity.Y = npc.velocity.Y - acceleration * 2f;
                    }
                    if (Math.Abs(dirX) < speed * 0.2 && (npc.velocity.Y > 0.0 && dirY < 0.0 || npc.velocity.Y < 0.0 && dirY > 0.0))
                    {
                        if (npc.velocity.X > 0.0)
                            npc.velocity.X = npc.velocity.X + acceleration * 2f;
                        else
                            npc.velocity.X = npc.velocity.X - acceleration * 2f;
                    }
                }
                else if (absDirX > absDirY)
                {
                    if (npc.velocity.X < dirX)
                        npc.velocity.X = npc.velocity.X + acceleration * 1.1f;
                    else if (npc.velocity.X > dirX)
                        npc.velocity.X = npc.velocity.X - acceleration * 1.1f;
                    if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < speed * 0.5)
                    {
                        if (npc.velocity.Y > 0.0)
                            npc.velocity.Y = npc.velocity.Y + acceleration;
                        else
                            npc.velocity.Y = npc.velocity.Y - acceleration;
                    }
                }
                else
                {
                    if (npc.velocity.Y < dirY)
                        npc.velocity.Y = npc.velocity.Y + acceleration * 1.1f;
                    else if (npc.velocity.Y > dirY)
                        npc.velocity.Y = npc.velocity.Y - acceleration * 1.1f;
                    if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < speed * 0.5)
                    {
                        if (npc.velocity.X > 0.0)
                            npc.velocity.X = npc.velocity.X + acceleration;
                        else
                            npc.velocity.X = npc.velocity.X - acceleration;
                    }
                }
            }
            npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;

            Player player = Main.LocalPlayer;
            if (Main.expertMode)
            {
                if (npc.active)
                {
                    Main.raining = true;
                    Main.rainTime = 60;
                    Main.maxRaining = 0.9f;
                    Main.windSpeed = 0.7f;
                }
                else
                {
                    Main.raining = false;
                    Main.rainTime = -60;
                    Main.maxRaining = -0.9f;
                    Main.windSpeed = -0.7f;
                }
            }
            else if (npc.active)
            {
                Main.raining = true;
                Main.rainTime = 60;
                Main.maxRaining = 0.65f;
                Main.windSpeed = 0.4f;
            }
            else
            {
                Main.raining = false;
                Main.rainTime = -60;
                Main.maxRaining = -0.65f;
                Main.windSpeed = -4;
            }
            if (collision)
            {
                if (npc.localAI[0] != 1)
                    npc.netUpdate = true;
                npc.localAI[0] = 1f;
            }
            else
            {
                if (npc.localAI[0] != 0.0)
                    npc.netUpdate = true;
                npc.localAI[0] = 0.0f;
            }
            {
                if (Main.player[npc.target].dead || npc.Distance(Main.LocalPlayer.Center) > 20000)
                {
                    npc.velocity.Y -= -0.1f;
                    npc.direction -= 1;
                    if (npc.timeLeft > 240)
                    {
                        npc.timeLeft = 240;
                    }
                }
                return false;
            }
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
                {
                    Main.PlaySound(-1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/AlphaFrostjawDeath"));
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlphaFrostjawHeadGore1"), npc.scale);
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlphaFrostjawHeadGore2"), npc.scale);
                }
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
            scale = 1.5f;
            return null;
        }
        public override void NPCLoot()
        {
            if (!FPWorld.downedAlphaFrostjawHead)
            {
                FPWorld.downedAlphaFrostjawHead = true;
                Main.NewText("The frostjaws are disturbed by your activity!", 150, 207, 255);
                Main.NewText("Small glittering matter is formed within the frostjaws' body!", 130, 180, 240);
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData);
                }
            }
            Item.NewItem(npc.getRect(), ItemID.LesserHealingPotion, Main.rand.Next(5, 15));
            if (Main.rand.NextFloat() < .10)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Placeable.AlphaFrostjawTrophy>());
            }
            if (Main.rand.NextFloat() < .1429)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Frostjaw.AlphaFrostjawMask>());
            }
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Frostjaw.FrostjawTooth>(), Main.rand.Next(8, 15));
                {
                    var dropChooser1 = new WeightedRandom<int>();
                    dropChooser1.Add(ModContent.ItemType<Items.Frostjaw.IcicleSpear>());
                    dropChooser1.Add(ModContent.ItemType<Items.Frostjaw.FrostjawsBreath>());
                    dropChooser1.Add(ModContent.ItemType<Items.Frostjaw.FrostboltStaff>());
                    dropChooser1.Add(ModContent.ItemType<Projectiles.Minions.IceFragments.IceFragmentItem>());
                    int choice1 = dropChooser1;
                    Item.NewItem(npc.getRect(), choice1);
                }
                {
                    var dropChooser2 = new WeightedRandom<int>();
                    dropChooser2.Add(ModContent.ItemType<Items.Frostjaw.IcicleSpear>());
                    dropChooser2.Add(ModContent.ItemType<Items.Frostjaw.FrostjawsBreath>());
                    dropChooser2.Add(ModContent.ItemType<Items.Frostjaw.FrostboltStaff>());
                    dropChooser2.Add(ModContent.ItemType<Projectiles.Minions.IceFragments.IceFragmentItem>());
                    int choice2 = dropChooser2;
                    Item.NewItem(npc.getRect(), choice2);
                }
            }
        }
     }
}
