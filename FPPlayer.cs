using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace FPenumbra
{
    public class FPPlayer : ModPlayer
    {
        public bool lowhealth;
        public int Timer1;
        public bool resistance;
        public int Timer2;
        public bool frozenheart;
        public bool summonnerf;
        public bool cryobean;
        public bool compliance;
        public bool livingregen;
        public bool stasiscooldown;
        public bool viledroneshoot;
        public bool energycleave;
        public bool virulencecurse;
        public bool meteorhood;
        public bool vileliquidator;
        public int Timer3;

        public override void ResetEffects()
        {
            frozenheart = false;
            resistance = false;
            summonnerf = false;
            cryobean = false;
            compliance = false;
            livingregen = false;
            stasiscooldown = false;
            viledroneshoot = false;
            energycleave = false;
            virulencecurse = false;
            meteorhood = false;
            vileliquidator = false;
        }
        public override void UpdateDead()
        {
            frozenheart = false;
            resistance = false;
            summonnerf = false;
            cryobean = false;
            compliance = false;
            livingregen = false;
            stasiscooldown = false;
            viledroneshoot = false;
            energycleave = false;
            virulencecurse = false;
            meteorhood = false;
            vileliquidator = false;
        }
        public override void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat)
        {
            if (meteorhood == true)
            {
                if (item.type == ItemID.BluePhaseblade ||
                    item.type == ItemID.BluePhasesaber ||
                    item.type == ItemID.GreenPhaseblade ||
                    item.type == ItemID.GreenPhasesaber ||
                    item.type == ItemID.PurplePhaseblade ||
                    item.type == ItemID.PurplePhasesaber ||
                    item.type == ItemID.PurplePhaseblade ||
                    item.type == ItemID.RedPhasesaber ||
                    item.type == ItemID.RedPhaseblade ||
                    item.type == ItemID.WhitePhasesaber ||
                    item.type == ItemID.WhitePhaseblade ||
                    item.type == ItemID.YellowPhasesaber ||
                    item.type == ItemID.YellowPhaseblade)
                {
                    add += 0.30f;
                }
            }
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (FPenumbra.StasisHotKey.JustPressed && frozenheart == true && !Main.LocalPlayer.HasBuff(ModContent.BuffType<Buffs.StasisCooldown>()))
            {
                player.AddBuff(ModContent.BuffType<Buffs.Cryostasis>(), 240);
                player.AddBuff(ModContent.BuffType<Buffs.StasisCooldown>(), 7200);
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/Cryostasis"));
            }
            if (FPenumbra.LiquidatorBoltsHotKey.JustPressed && vileliquidator == true && !Main.LocalPlayer.HasBuff(ModContent.BuffType<Buffs.LiquidatorBoltsCooldown>()))
            {
                player.AddBuff(ModContent.BuffType<Buffs.LiquidatorBoltsCooldown>(), 1200);
                {
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/LiquidatorBolts"));
                    float numberProjectiles = 8;
                    Vector2 velocity = new Vector2(0, 1.5f);
                    float rotation = MathHelper.ToRadians(180);
                    for (int i = 0; i < numberProjectiles; i++)
                    Projectile.NewProjectile(player.Center, -velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 2.5f, ModContent.ProjectileType<Projectiles.PrototypeVile.Protobolt>(), 80, 0f - Main.myPlayer, Main.myPlayer, Main.myPlayer);
                }
            }
        }
        public override void PostUpdate()
        {   //Low Health Indicator
            if (ModContent.GetInstance<FPenumbraConfig>().lowhealthsfx)
            {
                if (player.statLifeMax <= 100 && player.statLife <= 40 ||
                  player.statLifeMax >= 100 && player.statLifeMax <= 149 && player.statLife <= 40 ||
                  player.statLifeMax >= 150 && player.statLifeMax <= 199 && player.statLife <= 45 ||
                  player.statLifeMax >= 200 && player.statLifeMax <= 249 && player.statLife <= 50 ||
                  player.statLifeMax >= 250 && player.statLifeMax <= 299 && player.statLife <= 55 ||
                  player.statLifeMax >= 300 && player.statLifeMax <= 349 && player.statLife <= 60 ||
                  player.statLifeMax >= 350 && player.statLifeMax <= 399 && player.statLife <= 75 ||
                  player.statLifeMax >= 400 && player.statLifeMax <= 449 && player.statLife <= 80 ||
                  player.statLifeMax >= 450 && player.statLifeMax <= 499 && player.statLife <= 90 ||
                  player.statLifeMax >= 500 && player.statLifeMax <= 524 && player.statLife <= 100 ||
                  player.statLifeMax >= 525 && player.statLifeMax <= 549 && player.statLife <= 110 ||
                  player.statLifeMax >= 550 && player.statLifeMax <= 574 && player.statLife <= 120 ||
                  player.statLifeMax >= 575 && player.statLifeMax <= 599 && player.statLife <= 135 ||
                  player.statLifeMax >= 600 && player.statLifeMax <= 799 && player.statLife <= 150 ||
                  player.statLifeMax >= 800 && player.statLifeMax <= 999 && player.statLife <= 200 ||
                  player.statLifeMax >= 1000 && player.statLife <= 250)
                {
                    Timer1++;
                    if (Timer1 == 1)
                    {
                        Main.PlaySound(SoundLoader.customSoundType, player.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/LowHealth"));
                    }
                    if (Timer1 == 120)
                    {
                        Main.PlaySound(SoundLoader.customSoundType, player.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/Heartbeat"));
                        Timer1 = 60;
                    }
                }
                else
                {
                    Timer1 = 0;
                    Timer1--;
                }
            }
        }
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (frozenheart == true)
            {
                for (int i = 0; i < 12; i++)
                {
                    int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.FrostjawDust>(), 2 * hitDirection, -2f);
                }
                player.AddBuff(ModContent.BuffType<Buffs.FrozenShield>(), 360);
            }
            if (livingregen == true)
            {
                player.AddBuff(ModContent.BuffType<Buffs.LivingRegenCooldown>(), 720);
            }
            if (virulencecurse == true)
            {
                player.AddBuff(BuffID.Cursed, 105);
            }
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (meteorhood == true)
                if (item.type == ItemID.BluePhaseblade ||
                item.type == ItemID.BluePhasesaber ||
                item.type == ItemID.GreenPhaseblade ||
                item.type == ItemID.GreenPhasesaber ||
                item.type == ItemID.PurplePhaseblade ||
                item.type == ItemID.PurplePhasesaber ||
                item.type == ItemID.PurplePhaseblade ||
                item.type == ItemID.RedPhasesaber ||
                item.type == ItemID.RedPhaseblade ||
                item.type == ItemID.WhitePhasesaber ||
                item.type == ItemID.WhitePhaseblade ||
                item.type == ItemID.YellowPhasesaber ||
                item.type == ItemID.YellowPhaseblade)
                {
                    target.AddBuff(BuffID.OnFire, 150);
                }
        }
        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (energycleave == true)
            {
                if (Main.rand.NextBool(7))
                {
                    int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.FrostjawDust>());
                    Main.dust[dust].velocity /= 2f;
                    Main.playerDrawDust.Add(dust);
                }
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (resistance == true && !Main.LocalPlayer.HasBuff(ModContent.BuffType<Buffs.ResistanceCooldown>()))
            {
                if (damage >= 20)
                {
                    damage = 20;
                    player.AddBuff(ModContent.BuffType<Buffs.ResistanceCooldown>(), 3600);
                }
            }
            if (damageSource.SourceProjectileType == mod.ProjectileType("VileBomb"))
            {
                damageSource = PlayerDeathReason.ByCustomReason(player.name + " was bombarded.");
            }
            return true;
        }
    } 
}