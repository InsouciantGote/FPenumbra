using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FPenumbra.Projectiles
{
	public class CryomancerProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryomancer's Snowflake");
		}

		public override void SetDefaults() 
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.alpha = 0;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 180;
			projectile.ignoreWater = true;
			projectile.magic = true;
			projectile.extraUpdates = 3;
		}

		public override void AI()
		{
			if (projectile.soundDelay == 0)
			{
				float num1 = 99999f;
				if (num1 < 99999)
					num1 = 99999f;
				projectile.soundDelay = (int)num1;
				Main.PlaySound(SoundID.Item30, projectile.Center);
			};
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0f) / 255f, ((255 - projectile.alpha) * 0.5f) / 255f, ((255 - projectile.alpha) * 0.5f) / 255f);
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
            Vector2 move = Vector2.Zero;
			projectile.rotation += 0.01f;
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
			Main.PlaySound(SoundID.Item27, projectile.Center);
			if (projectile.ai[1] == 0)
			{
				for (int i = 0; i < 12; i++)
				{
					Vector2 vel = new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(4, -4));
					Projectile.NewProjectile(projectile.Center, vel, mod.ProjectileType("CryomancerSplitProjectile"), projectile.damage / 2, projectile.knockBack / 2, projectile.owner);
				}
			}

			for (int i = 0; i < 17; i++)
			{
				int dust1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.CryoDust>());
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
	}
}
