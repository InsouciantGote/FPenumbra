using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles.Minions.VileDrones
{

	public class VileDroneMinionBuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Vile Drone");
			Description.SetDefault("- PROTECTION PROTOCOL INITIATED; WILL ATTACK ANY HOSTILE TARGET ON SIGHT -");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ModContent.ProjectileType<VileDroneMinion>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}

	public class VileDroneItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Vile Drone Console");
			Tooltip.SetDefault("Summons a vile drone to fight for you" +
				"\nEach minion takes 3/4 of a minion slot");
			Item.staff[item.type] = true;
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 18;
			item.knockBack = 3f;
			item.mana = 18;
			item.width = 46;
			item.height = 36;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 120000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/VileDroneSummon"); ;
			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<VileDroneMinionBuff>();
			item.shoot = ModContent.ProjectileType<VileDroneMinion>();
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			for (int i = 0; i < 16; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(position.X, position.Y), 0, 0, ModContent.DustType<Dusts.VileEnergyDust>(), 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].scale = 1.4f;
				Main.dust[dustIndex].noGravity = false;
				Main.dust[dustIndex].velocity *= 2f;
				dustIndex = Dust.NewDust(new Vector2(position.X, position.Y), 0, 0, ModContent.DustType<Dusts.VileEnergyDust>(), 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex].scale = 0.7f;
				Main.dust[dustIndex].noGravity = false;
				Main.dust[dustIndex].velocity *= 0.75f;
			}
			return true;
		}
	}

	public class VileDroneMinion : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Vile Drone");
			Main.projFrames[projectile.type] = 4;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public sealed override void SetDefaults() {
			projectile.width = 22;
			projectile.height = 34;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 0.75f;
			projectile.penetrate = -1;
		}

		public override bool? CanCutTiles() {
			return true;
		}

		public override bool MinionContactDamage() {
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];

			#region Active check
			if (player.dead || !player.active) {
				player.ClearBuff(ModContent.BuffType<VileDroneMinionBuff>());
			}
			if (player.HasBuff(ModContent.BuffType<VileDroneMinionBuff>())) {
				projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 42f;
			float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
			idlePosition.X += minionPositionOffsetX;
			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f) {
				projectile.position = idlePosition;
				projectile.velocity *= 1f;
				projectile.netUpdate = true;
			}
			float overlapVelocity = 1f;
			for (int i = 0; i < Main.maxProjectiles; i++) {
				Projectile other = Main.projectile[i];
				if (i != projectile.whoAmI && other.active && other.owner == projectile.owner && Math.Abs(projectile.position.X - other.position.X) + Math.Abs(projectile.position.Y - other.position.Y) < projectile.width) {
					if (projectile.position.X < other.position.X) projectile.velocity.X -= overlapVelocity;
					else projectile.velocity.X += overlapVelocity;

					if (projectile.position.Y < other.position.Y) projectile.velocity.Y -= overlapVelocity;
					else projectile.velocity.Y += overlapVelocity;
				}
			}
			#endregion

			#region Find target
			float distanceFromTarget = 500f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;
			if (player.HasMinionAttackTargetNPC) {
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
				if (between < 2000f) {
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			projectile.friendly = foundTarget;
			#endregion

			#region Movement

			float speed = 80f;
			float inertia = 40f;

			if (foundTarget) {
				if (distanceFromTarget > 40f) {
					Vector2 direction = targetCenter - projectile.Center;
					direction.Normalize();
					direction *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}
			else {
				if (distanceToIdlePosition > 600f) {
					speed = 12f;
					inertia = 20f;
				}
				else {
					speed = 6f;
					inertia = 40f;
				}
				if (distanceToIdlePosition > 10f) {
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (projectile.velocity == Vector2.Zero) {
					projectile.velocity.X = -0.15f;
					projectile.velocity.Y = -0.05f;
				}
			}
			#endregion

			#region Animation and visuals
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(-90);
			int frameSpeed = 9;
			projectile.frameCounter++;
			if (projectile.frameCounter >= frameSpeed) {
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type]) {
					projectile.frame = 0;
				}
			}

			Lighting.AddLight(projectile.Center, Color.Purple.ToVector3() * 0.5f);
			#endregion
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
	}
}
