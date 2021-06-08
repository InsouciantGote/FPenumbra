using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles.PrototypeVile
{
	public class VileLaser : ModProjectile
	{

		public override void SetDefaults() 
		{
			projectile.npcProj = true;
			projectile.width = 46;
			projectile.height = 2;
			projectile.alpha = 0;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 3;
			projectile.scale = 1.5f;
			projectile.aiStyle = 1;
			aiType = ProjectileID.EyeBeam;
			drawOriginOffsetX = 2;
		}

		public override void AI()
		{
			if (projectile.soundDelay == 0)
			{
				float num1 = 99999f;
				if (num1 < 99999)
					num1 = 99999f;
				projectile.soundDelay = (int)num1;
				Main.PlaySound(SoundID.Item33, projectile.Center);
			};
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
	}
}
