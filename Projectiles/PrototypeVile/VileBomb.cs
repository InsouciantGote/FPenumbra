using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FPenumbra.Projectiles.PrototypeVile
{
	public class VileBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 8;
		}

		public override void SetDefaults() 
		{
			projectile.npcProj = true;
			projectile.width = 22;
			projectile.height = 22;
			projectile.alpha = 0;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 3;
			projectile.penetrate = 1;
			drawOriginOffsetY = 2;
		}

		public override void AI()
        {
			{
			projectile.rotation += projectile.velocity.Y * 0.01f;
			projectile.velocity.Y += 0.01f;
			if (projectile.active == false)
			{
				projectile.tileCollide = false;
				projectile.alpha = 255;
				projectile.position = projectile.Center;
				projectile.damage = 56;
				projectile.width = 100;
				projectile.height = 100;
				projectile.Center = projectile.position;
				projectile.knockBack = 6f;
			}
				Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.4f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.4f) / 255f);
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
				if (projectile.localAI[0] == 0f)
				{
					AdjustMagnitude(ref projectile.velocity);
					projectile.localAI[0] = 1f;
				}
				if (++projectile.frameCounter >= 9)
				{
					projectile.frameCounter = 0;
					if (++projectile.frame >= 8)
					{
						projectile.frame = 0;
					}
				}
				Vector2 move = Vector2.Zero;
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
			for (int i = 0; i < 5; i++)
			{
				int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.VileScrap>());
			}
			Main.PlaySound(SoundID.Item14, projectile.position);
			// Smoke Dust spawn
			for (int i = 0; i < 50; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 0.8f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			// Fire Dust spawn
			for (int i = 0; i < 12; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.VileEnergyDust>(), 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].noGravity = false;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.VileEnergyDust>(), 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex].velocity *= 3f;
				for (int g = 0; g < 2; g++)
				{
					int goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[goreIndex].scale = 0.4f;
					Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
					Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
					goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[goreIndex].scale = 0.4f;
					Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
					Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
					goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[goreIndex].scale = 0.4f;
					Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
					Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
				}
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			projectile.timeLeft = 0;
			if (Main.expertMode)
			{
				if (WorldGen.crimson == true)
				{ target.AddBuff(BuffID.Ichor, 300); }
				if (WorldGen.crimson == false)
				{ target.AddBuff(BuffID.Ichor, 300); }
			}
		}
	}
}
