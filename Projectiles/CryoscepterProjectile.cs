using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles
{
	public class CryoscepterProjectile : ModProjectile
	{

		public override void SetDefaults() 
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.alpha = 0;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.magic = true;
			projectile.timeLeft = 480;
			projectile.scale = 1.5f;
			projectile.penetrate = 3;
			projectile.extraUpdates = 3;
			drawOriginOffsetY = 2;
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
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.5f) / 255f, ((255 - projectile.alpha) * 0.55f) / 255f, ((255 - projectile.alpha) * 0.6f) / 255f);
			if (projectile.alpha > 0)
			{
				projectile.alpha = 0;
			}
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			if (Main.rand.NextBool(2))
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.FrostjawDust>());
				Main.dust[dust].velocity /= 2f;
			}
			Vector2 move = Vector2.Zero;
			projectile.rotation = projectile.velocity.ToRotation();
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
			for (int i = 0; i < 7; i++)
			{
				int dust1 = Dust.NewDust(projectile.Center, projectile.width, projectile.height, ModContent.DustType<Dusts.CryoDust>());
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			{ target.AddBuff(BuffID.Frostburn, 90); }
			projectile.velocity = -projectile.velocity;
		}
	}
}
