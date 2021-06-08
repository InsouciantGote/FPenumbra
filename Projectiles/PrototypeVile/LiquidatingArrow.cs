using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles.PrototypeVile
{
	public class LiquidatingArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 4;
		}
		public override void SetDefaults()
		{
			projectile.width = 42;
			projectile.height = 14;
			projectile.alpha = 20;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.melee = false;
			projectile.ranged = true;
			projectile.timeLeft = 3600000;
			projectile.penetrate = 1;
			projectile.extraUpdates = 3;
			projectile.velocity /= 4;

		}

		public override void AI()
		{
			if (projectile.soundDelay == 0)
			{
				float num1 = 99999f;
				if (num1 < 99999)
					num1 = 99999f;
				projectile.soundDelay = (int)num1;
				Main.PlaySound(SoundID.Item9, projectile.Center);
			};
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.20f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f, ((255 - projectile.alpha) * 0.20f) / 255f);
			if (projectile.alpha > 0)
			{
				projectile.alpha = 0;
			}
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			for (int i = 0; i < 2; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.VileEnergyDust>());
				if (Main.rand.NextBool(2))
				{
					Main.dust[dust].scale = 1.5f * projectile.scale;
					Main.dust[dust].velocity = -projectile.velocity / 20;
				}
				else
				{
					Main.dust[dust].scale = 0.8f * projectile.scale;
					Main.dust[dust].velocity = -projectile.velocity / 20;
				}
			}

			if (++projectile.frameCounter >= 5)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
				{
					projectile.frame = 0;
				}
			}
			projectile.rotation = projectile.velocity.ToRotation();
		}
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 25f)
			{
				vector *= 25f / magnitude;
			}
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.Center);
			for (int i = 0; i < 12; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.VileEnergyDust>());
				{
					Main.dust[dust].scale = 1.4f * projectile.scale;
					Main.dust[dust].velocity *= 2f;
				}
			}
			Projectile.NewProjectile(projectile.Center, new Vector2(3, 3), ModContent.ProjectileType<Projectiles.PrototypeVile.LiquidatingOrb>(), projectile.damage / 2, projectile.knockBack, projectile.owner);
			Projectile.NewProjectile(projectile.Center, new Vector2(3, -3), ModContent.ProjectileType<Projectiles.PrototypeVile.LiquidatingOrb>(), projectile.damage / 2, projectile.knockBack, projectile.owner);
			Projectile.NewProjectile(projectile.Center, new Vector2(-3, 3), ModContent.ProjectileType<Projectiles.PrototypeVile.LiquidatingOrb>(), projectile.damage / 2, projectile.knockBack, projectile.owner);
			Projectile.NewProjectile(projectile.Center, new Vector2(-3, -3), ModContent.ProjectileType<Projectiles.PrototypeVile.LiquidatingOrb>(), projectile.damage / 2, projectile.knockBack, projectile.owner);
		}
	}
}
