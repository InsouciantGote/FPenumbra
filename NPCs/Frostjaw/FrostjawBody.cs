using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.NPCs.Frostjaw
{
    public class FrostjawBody : ModNPC
    {
        public int Timer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostjaw");
        }
        public override void SetDefaults()
        {
            npc.width = 20;
            npc.height = 5;
            npc.damage = 15;
            npc.defense = 20;
            npc.lifeMax = 170;
            npc.knockBackResist = 0.0f;
            npc.behindTiles = true;
            npc.noTileCollide = true;
            npc.netAlways = true;
            npc.noGravity = true;
            npc.dontCountMe = true;
            npc.friendly = false;
            npc.HitSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/FrostjawHit");
            npc.npcSlots = 0;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.buffImmune[BuffID.Frozen] = true;
        }

        public override bool PreAI()
        {
            if (npc.ai[3] > 0)
                npc.realLife = (int)npc.ai[3];
            if (npc.target < 0 || npc.target == byte.MaxValue || Main.player[npc.target].dead)
                npc.TargetClosest(true);
            if (Main.player[npc.target].dead && npc.timeLeft > 300)
                npc.timeLeft = 300;

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
                float dist = (length - (float)npc.width) / length;
                float posX = dirX * dist;
                float posY = dirY * dist;
                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + posX;
                npc.position.Y = npc.position.Y + posY;
            }
            if (FPWorld.downedAlphaFrostjawHead == true)
            {
                Timer++;
                if (Timer == 1)
                {
                    if (!Main.expertMode)
                    {
                        npc.lifeMax = 270;
                        npc.life = 270;
                        npc.damage += 9;
                    }
                    else
                    {
                        npc.lifeMax = 520;
                        npc.life = 520;
                        npc.damage += 17;
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
            if (npc.life <= 0 && player.active)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FrostjawBodyGore1"), npc.scale);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FrostjawBodyGore2"), npc.scale);
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