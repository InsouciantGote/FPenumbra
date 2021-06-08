using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles.Frostjaw
{
	public class FrostboltProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostbolt");
		}

		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.alpha = 0;
			projectile.friendly = true;
			projectile.tileCollide = true;
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
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item27, projectile.Center);
			for (int i = 0; i < 5; i++)
			{
				int dust1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.FrostjawDust>());
			}
			for (int i = 0; i < 8; i++)
			{
				int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.FrostjawShards>());
				Main.dust[dust2].noGravity = false;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			{ target.AddBuff(BuffID.Frostburn, 90); }
			if (target.HasBuff(BuffID.Frostburn))
			{
				projectile.damage += 12;
			}
		}
	}
}
