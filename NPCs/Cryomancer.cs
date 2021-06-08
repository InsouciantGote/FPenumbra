using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.Events;

namespace FPenumbra.NPCs
{
	[AutoloadHead]
	public class Cryomancer : ModNPC
	{
		public override string Texture => "FPenumbra/NPCs/Cryomancer";

		public override string[] AltTextures => new[] { "FPenumbra/NPCs/Cryomancer_Alt_1" };

		public override bool Autoload(ref string name) {
			name = "Cryomancer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() {
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 20;
			npc.defense = 35;
			npc.lifeMax = 700;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.ArmsDealer;
		}

		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood);
			}
			Player player = Main.LocalPlayer;
			if (npc.life <= 0 && player.active)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CryomancerGore1"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CryomancerGore2"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CryomancerGore3"), npc.scale);
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];
				if (!player.active) {
					continue;
				}

				if (FPWorld.downedAlphaFrostjawHead == true || Main.hardMode == true)
				{
				return true;
				}
			}
			return false;
		}


		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(6)) {
				case 0:
					return "Mythril";
				case 1:
					return "Azule";
				case 2:
					return "Mythriel";
				case 3:
					return "Jack";
				case 4:
					return "Kari";
				default:
					return "Aster";

			}
		}

		public override string GetChat() {
			int goblinTinkerer = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
			int demoMan = NPC.FindFirstNPC(NPCID.Demolitionist);
			int cryomancer = NPC.FindFirstNPC(ModContent.NPCType<Cryomancer>());
			if (Main.npc[cryomancer].GivenName == "Mythril" == true && Main.rand.NextBool(12))
				return "If you are thinking of getting one of the hardmode ores from me, then you are sorely mistaken.";
			if (goblinTinkerer >= 0 && Main.rand.NextBool(12))
				return "Seriously? Did " + Main.npc[goblinTinkerer].GivenName + " break my spear again!?";
			if (goblinTinkerer >= 0 && Main.rand.NextBool(12))
				return "Seriously? " + Main.npc[goblinTinkerer].GivenName + " broke my spell book again! How did he even break a book?";
			if (goblinTinkerer >= 0 && Main.rand.NextBool(12))
				return "I swear I'm gonna be out of coins from " + Main.npc[goblinTinkerer].GivenName + " if he keeps messing up his reforges.";
			if (demoMan >= 0 && Main.rand.NextBool(12))
				return "I swear, " + Main.npc[demoMan].GivenName + ", if you turn my ice sculpture into pieces, I'm going to have another one in my collection.";
			if (demoMan >= 0 && Main.rand.NextBool(12))
				return "I really don't want to live next with " + Main.npc[demoMan].GivenName + " he really likes to test his explosives on my stuff.";
			if (Main.LocalPlayer.GetModPlayer<FPPlayer>().cryobean == true && Main.rand.NextBool(12))
				return "Did you rummage through my closet or have killed one of my clones? Either way, I'm not amused.";
			if (Main.LocalPlayer.GetModPlayer<FPPlayer>().cryobean == true && Main.rand.NextBool(12))
				return "Wow! nice beanie, " + Main.LocalPlayer.name + ". Where did... you know what? Don't answer.";
			if (Main.bloodMoon && Main.rand.NextBool(12))
				return "You should probably block up the doors right now, or else there would be a lot of casualties.";
			if (FPWorld.downedAlphaFrostjawHead == true && Main.hardMode == false && Main.rand.NextBool(12))
				return "It is dangerous to roam around the snow with the frostjaws becoming more aggressive there, but I do happen to have the stuff for that.";
			if (BirthdayParty.PartyIsUp == true && Main.rand.NextBool(12))
				return "Hmm... All I have in my mind is some ice cream and probably chips.";
			if (BirthdayParty.PartyIsUp == true && Main.rand.NextBool(12))
				return "Oh! I hope that someone brought something quite cold.";
			if (Main.LocalPlayer.HasBuff(BuffID.Frostburn) && Main.rand.NextBool(12))
				return "Freezing? Burning? It’ll all the same to me.";
			if (Main.LocalPlayer.HasBuff(BuffID.Warmth) && Main.rand.NextBool(12))
				return "Drank something to protect yourself from the cold, I see. I can’t blame for normally not finding higher temperatures comfortable.";
			if (Main.LocalPlayer.HasBuff(BuffID.Warmth) && Main.rand.NextBool(12))
				return "Looks like you don’t need a jacket to protect against the cold after all.";
			if (Main.LocalPlayer.HasBuff(BuffID.Inferno) && Main.rand.NextBool(12))
				return "Keep that flame of yours under control, will you? No? Fine.";
			if (Main.LocalPlayer.HasBuff(BuffID.Inferno) && Main.rand.NextBool(12))
				return "My power won’t wane with that much heat that you have right now, but you’ll melt my ice sculptures.";
			if (Main.LocalPlayer.HasBuff(BuffID.Chilled) && Main.rand.NextBool(12))
				return "Cold, isn't it, " + Main.LocalPlayer.name + "?";
			if (Main.LocalPlayer.HasBuff(BuffID.Chilled) && Main.rand.NextBool(12))
				return "Fought with some cold creatures recently?";
			if (Main.LocalPlayer.HasBuff(BuffID.Chilled) && Main.rand.NextBool(12))
				return "I'd help you fight the cold that you're experiencing right now, but it'll take a lot of training to be a cryomancer. There's a quicker way though.";
			if (Main.LocalPlayer.HasBuff(BuffID.OnFire) && Main.rand.NextBool(12))
				return "Keep that flame of yours under control, will you? No? Fine.";
			if (Main.LocalPlayer.HasBuff(BuffID.PigronMount) && Main.rand.NextBool(12))
				return "I like your mount.";
			if (Main.LocalPlayer.HasBuff(BuffID.PigronMount) && Main.rand.NextBool(12))
				return "I have yet to ride a pigron like that. It looks like a fun ride to me.";
			if (Main.LocalPlayer.HasItem(ItemID.IceRod) && Main.rand.NextBool(12))
				return "Is that an ice rod? Nice! You bought that, right?";
			switch (Main.rand.Next(6)) {
				case 0:
					return "Hey there! What do you need me to do? Make an ice sculpture or refreeze your ice cream?";
				case 1:
					return "You need freezing services, " + Main.LocalPlayer.name + "?";
				case 2:
					return "The snow in this place is great, but the frostjaws don't really trust us humans.";
                case 3:
					return "I don't need a fancy outfit to be a true cryomancer. It's all about power and skill.";
				case 4:
					return "Ice puns? Don't bother.";
				default:
					return "Want me to be your personal freezer for a while?";
			}
		}
		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}
		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

        public override void SetupShop(Chest shop, ref int nextSlot) {
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Frostjaw.BlizzardCore>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Accessories.ExaltingPendant>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.CryomancersSpellbook>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.IceMachine);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.IceMirror);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.IceTorch);
			nextSlot++;
			if (Main.LocalPlayer.HasItem(ItemID.SnowballCannon) || Main.LocalPlayer.HasItem(ItemID.SnowballLauncher))
			shop.item[nextSlot].SetDefaults(ItemID.Snowball);
			nextSlot++;
		}


			public override void NPCLoot() {
			int cryomancer = NPC.FindFirstNPC(ModContent.NPCType<Cryomancer>());
			if (Main.npc[cryomancer].GivenName == "Mythriel")
				{ 
					Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Vanity.CryomancerBeanie>()); 
				}
			}
		public override bool CanGoToStatue(bool toKingStatue) {
			return true;
		}

		public override void OnGoToStatue(bool toKingStatue) {
			if (Main.netMode == NetmodeID.Server) {
				ModPacket packet = mod.GetPacket();
				packet.Write((byte)npc.whoAmI);
				packet.Send();
			}
			else {
				StatueTeleport();
			}
		}

		public void StatueTeleport() {
			for (int i = 0; i < 30; i++) {
				Vector2 position = Main.rand.NextVector2Square(-20, 21);
				if (Math.Abs(position.X) > Math.Abs(position.Y)) {
					position.X = Math.Sign(position.X) * 20;
				}
				else {
					position.Y = Math.Sign(position.Y) * 20;
				}
				Dust.NewDustPerfect(npc.Center + position, ModContent.DustType<Dusts.FrostjawDust>(), Vector2.Zero).noGravity = true;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 35;
			knockback = 3f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 15;
			randExtraCooldown = 15;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ModContent.ProjectileType<Projectiles.CryomancerProjectile>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 1f;
		}
	}
}
