using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles.PrototypeVile
{
	public class Protolaser : ModProjectile
	{

		public override void SetDefaults() 
		{
			projectile.width = 9;
			projectile.height = 6;
			projectile.alpha = 0;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 3;
			projectile.scale = 1.5f;
			drawOriginOffsetX = Main.LocalPlayer.direction;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.15f) / 255f, ((255 - projectile.alpha) * 0.2f) / 255f, ((255 - projectile.alpha) * 0.15f) / 255f);
			if (projectile.alpha > 0)
			{
				projectile.alpha = 0;
			}
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			projectile.rotation = projectile.velocity.ToRotation();
            Vector2 move = Vector2.Zero;
		}

		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 6f / magnitude;
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
        public override void Kill(int timeLeft)
        {
			Projectile.NewProjectile(new Vector2(projectile.position.X + 5, projectile.position.Y + 5), new Vector2(0), ModContent.ProjectileType<Projectiles.PrototypeVile.EnergyBlast>(), projectile.damage + 12, 0, Main.myPlayer, Main.myPlayer);
		}
    }
}