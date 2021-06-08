using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles
{
	public class FocusedArrow : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.width = 32;
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

		}

		public override void AI()
		{

			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.00f) / 255f, ((255 - projectile.alpha) * 0.5f) / 255f, ((255 - projectile.alpha) * 0.5f) / 255f);
			if (projectile.alpha > 0)
			{
				projectile.alpha = 0;
			}
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			if (Main.rand.NextBool(4))
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.EnchantedDust>());
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

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.Center);
			for (int i = 0; i < 15; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.EnchantedDust>());
			}
		}
	}
}
