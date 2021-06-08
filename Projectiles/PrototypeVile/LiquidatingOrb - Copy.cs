using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles.PrototypeVile
{
	public class LiquidatingOrb : ModProjectile
	{
		public int Timer;
		public override void SetStaticDefaults() 
		{
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults() 
		{
			projectile.width = 0;
			projectile.height = 0;
			projectile.alpha = 0;
			projectile.friendly = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.ranged = true;
			projectile.extraUpdates = 3;
			projectile.scale = 1f;
			projectile.timeLeft = 360;
			drawOriginOffsetY = 2;
		}

		public override void AI()
		{
			Timer++;
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.15f) / 255f, ((255 - projectile.alpha) * 0.02f) / 255f, ((255 - projectile.alpha) * 0.15f) / 255f);
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.LiquidatingOrbDust>());
				if (Main.rand.NextBool(2))
				{
					Main.dust[dust].scale = 0.9f;
					Main.dust[dust].velocity *= 0;
				}
				else
				{
					Main.dust[dust].scale = 0.7f;
					Main.dust[dust].velocity *= 0;
				}
			}
			if (Timer >= 60)
			{
				projectile.width = 10;
				projectile.height = 10;
				projectile.friendly = true;
				if (projectile.localAI[0] == 0f)
				{
					AdjustMagnitude(ref projectile.velocity);
					projectile.localAI[0] = 1f;
				}
				Vector2 move = Vector2.Zero;
				float distance = 400f;
				bool target = false;
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
					{
						Vector2 newMove = Main.npc[k].Center - projectile.Center;
						float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
						if (distanceTo < distance)
						{
							move = newMove;
							distance = distanceTo;
							target = true;
						}
					}
				}
				if (target)
				{
					AdjustMagnitude(ref move);
					projectile.velocity = (10 * projectile.velocity + move) / 11f;
					AdjustMagnitude(ref projectile.velocity);
				}
			}
		}

		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 6f / magnitude;
			}
		}
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 12; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.VileEnergyDust>());
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
	}
}