using FPenumbra.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles
{
	public class FleckOfNatureProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fleck of Nature");
		}

		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.alpha = 0;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.melee = false;
			projectile.magic = true;
			projectile.timeLeft = 360;
			projectile.penetrate = 1;
			projectile.extraUpdates = 3;

		}

		public override void AI()
		{
			{
				if (projectile.soundDelay == 0)
				{
					float num1 = 99999f;
					if (num1 < 99999)
						num1 = 99999f;
					projectile.soundDelay = (int)num1;
					Main.PlaySound(SoundID.Item8, projectile.Center);
				}
			}
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.2f) / 255f, ((255 - projectile.alpha) * 0.5f) / 255f, ((255 - projectile.alpha) * 0.5f) / 255f);
			if (projectile.alpha > 0)
			{
				projectile.alpha = 0;
			}
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<FleckOfNature1>());
				Main.dust[dust].velocity /= 2f;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<FleckOfNature2>());
				Main.dust[dust].velocity /= 2f;
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
		public override void Kill(int timeLeft)
		{
			if (projectile.ai[1] == 0)
			{
				{
					for (int t = 0; t < 1; t++)
					{
						Vector2 vel = new Vector2(0, 0);
						Projectile.NewProjectile(projectile.Center, vel, ModContent.ProjectileType<FleckOfNatureBlast>(), projectile.damage, projectile.knockBack, projectile.owner);
					}
				}
			}
			Main.PlaySound(SoundID.Item74, projectile.position);
			for (int i = 0; i < 80; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<FleckOfNature1>());
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 1.4f;
				dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<FleckOfNature2>());
				Main.dust[dustIndex].velocity *= 0.3f;
			}
		}
	}
}
