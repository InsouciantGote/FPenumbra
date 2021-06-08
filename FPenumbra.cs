using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using FPenumbra.Items.Frostjaw;
using FPenumbra.Items.PrototypeVile;

namespace FPenumbra
{
    public class FPenumbra : Mod
    {
        public static ModHotKey StasisHotKey;
        public static ModHotKey LiquidatorBoltsHotKey;
        public int Timer1;
        public override void Load()
        {
            StasisHotKey = RegisterHotKey("Stasis", "Y");
            LiquidatorBoltsHotKey = RegisterHotKey("Liquidator Bolts", "B");
        }
        public override void Unload()
        {
            StasisHotKey = null;
            LiquidatorBoltsHotKey = null;
        }
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call("AddToBossLoot", "Terraria", "KingSlime", new List<int> { ModContent.ItemType<Items.Accessories.Fragments.Insistence>() });
                bossChecklist.Call("AddToBossLoot", "Terraria", "EyeofCthulhu", new List<int> { ModContent.ItemType<Items.Accessories.Fragments.Vigilance>() });
                bossChecklist.Call("AddToBossLoot", "Terraria", "EaterofWorlds", new List<int> { ModContent.ItemType<Items.Accessories.Fragments.Decadence>() });
                bossChecklist.Call("AddToBossLoot", "Terraria", "BrainofCthulhu", new List<int> { ModContent.ItemType<Items.Accessories.Fragments.Intelligence>() });
                bossChecklist.Call("AddToBossLoot", "Terraria", "QueenBee", new List<int> { ModContent.ItemType<Items.Accessories.Fragments.Prevalence>() });
                {
                    bossChecklist.Call(
                      "AddBoss",
                      2.5f,
                      ModContent.NPCType<NPCs.Frostjaw.AlphaFrostjawHead>(),
                      this, // Mod
                      "Alpha Frostjaw",
                      (Func<bool>)(() => FPWorld.downedAlphaFrostjawHead),
                      ModContent.ItemType<Items.Frostjaw.BlizzardCore>(),
                      new List<int> {
                        ModContent.ItemType<Items.Placeable.AlphaFrostjawTrophy>(),
                        ModContent.ItemType<Items.Frostjaw.AlphaFrostjawMask>()},
                      new List<int> {
                        ModContent.ItemType<Items.Frostjaw.AlphaFrostjawBag>(),
                        ModContent.ItemType<Items.Accessories.Expert.FrozenHeart>(),
                        ModContent.ItemType<Items.Accessories.Fragments.Compliance>(),
                        ModContent.ItemType<Items.Frostjaw.IcicleSpear>(),
                        ModContent.ItemType<Items.Frostjaw.FrostjawsBreath>(),
                        ModContent.ItemType<Items.Frostjaw.FrostboltStaff>(),
                        ModContent.ItemType<Projectiles.Minions.IceFragments.IceFragmentItem>(),
                        ModContent.ItemType<Items.Frostjaw.FrostjawTooth>(),
                        ItemID.LesserHealingPotion },
                      "Use [i:" + ModContent.ItemType<BlizzardCore>() + "] in a Snow biome",
                      "[c/8dc2f2:The ice guardian has ceased the chaotic blizzard and left in peace.]",
                      "FPenumbra/NPCs/Frostjaw/AlphaFrostjawChecklist",
                      "FPenumbra/NPCs/Frostjaw/AlphaFrostjawHead_Head_Boss");
                }
                { bossChecklist.Call(
                    "AddBoss",
                    5.5f,
                    ModContent.NPCType<NPCs.PrototypeVile.PrototypeVile>(),
                    this, // Mod
                    "V.I.L.E.",
                    (Func<bool>)(() => FPWorld.downedPrototypeVile),
                    ModContent.ItemType<Items.PrototypeVile.Protobeacon>(),
                    new List<int> {
                        ModContent.ItemType<Items.Placeable.PrototypeVileTrophy>(),
                        ModContent.ItemType<Items.PrototypeVile.PrototypeVileMask>()},
                    new List<int> {
                        ModContent.ItemType<Items.PrototypeVile.PrototypeVileBag>(),
                        ModContent.ItemType<Items.Accessories.Fragments.Virulence>(),
                        ModContent.ItemType<Items.PrototypeVile.EnergyCleaver>(),
                        ModContent.ItemType<Items.PrototypeVile.LiquidatorBow>(),
                        ModContent.ItemType<Items.PrototypeVile.Protoblaster>(),
                        ModContent.ItemType<Projectiles.Minions.VileDrones.VileDroneItem>(),
                        ModContent.ItemType<Items.PrototypeVile.LiquidatorScrap>(),
                    ItemID.LesserHealingPotion },
                    "Use [i:" + ModContent.ItemType<Protobeacon>() + "]",
                    "[c/af4fff:TARGET LIQUIDATED, RESTORING SYSTEM TO SCOUTING PROTOCOLS.]",
                    "FPenumbra/NPCs/PrototypeVile/PrototypeVileChecklist",
                    "FPenumbra/NPCs/PrototypeVile/PrototypeVile_Head_Boss"); }
                // Additional bosses here
            }
            Mod yabhb = ModLoader.GetMod("FKBossHealthBar");
            if (yabhb != null)
            {
               {
                    yabhb.Call("hbStart");
                    yabhb.Call("hbSetTexture",
                        GetTexture("UI/AFJLeftBar"),
                        GetTexture("UI/AFJMidBar"),
                        GetTexture("UI/AFJRightBar"),
                        GetTexture("UI/AFJMidFill"));
                    yabhb.Call("hbSetTextureSmall",
                        GetTexture("UI/AFJLeftBar_Small"),
                        GetTexture("UI/AFJMidBar_Small"),
                        GetTexture("UI/AFJRightBar_Small"),
                        GetTexture("UI/AFJMidFill_Small"));
                    yabhb.Call("hbLoopMidBar", true);
                    yabhb.Call("hbFinishSingle", ModContent.NPCType<NPCs.Frostjaw.AlphaFrostjawHead>());
                }
                {
                    yabhb.Call("hbStart");
                    yabhb.Call("hbSetTexture",
                        GetTexture("UI/VILELeftBar"),
                        GetTexture("UI/VILEMidBar"),
                        GetTexture("UI/VILERightBar"),
                        GetTexture("UI/VILEMidFill"));
                    yabhb.Call("hbSetTextureSmall",
                        GetTexture("UI/VILELeftBar_Small"),
                        GetTexture("UI/VILEMidBar_Small"),
                        GetTexture("UI/VILERightBar_Small"),
                        GetTexture("UI/VILEMidFill_Small"));
                    yabhb.Call("hbLoopMidBar", true);
                    yabhb.Call("hbFinishSingle", ModContent.NPCType<NPCs.PrototypeVile.PrototypeVile>());
                }
            }
        }
    }
}