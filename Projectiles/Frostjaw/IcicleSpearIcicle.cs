using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles.Frostjaw
{
	public class IcicleSpearIcicle : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icicle Spear");
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 22;
			projectile.alpha = 0;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.melee = true;
			projectile.timeLeft = 60;
			projectile.penetrate = 2;
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
					Main.PlaySound(SoundID.Item30, projectile.Center);
				}
			}
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.7f) / 255f, ((255 - projectile.alpha) * 0.7f) / 255f);
			if (projectile.alpha > 0)
			{
				projectile.alpha = 0;
			}
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			if (Main.rand.NextBool(5))
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.FrostjawDust>());
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
	}
}
