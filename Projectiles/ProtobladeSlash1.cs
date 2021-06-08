using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FPenumbra.Projectiles
{
	public class ProtobladeSlash1 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Protoblade");
			Main.projFrames[projectile.type] = 5;
		}

		public override void SetDefaults()
		{
			projectile.width = 52;
			projectile.height = 100;
			projectile.alpha = 30;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.melee = true;
			projectile.timeLeft = 3600;
			projectile.penetrate = -1;
			projectile.ownerHitCheck = true;
			projectile.extraUpdates = 3;
		}

		public override void AI()
		{
			Vector2 mousePos = Main.MouseWorld;
			Player player = Main.player[projectile.owner];



			if (projectile.owner == Main.myPlayer)
			{
				Vector2 diff = mousePos - player.Center;
				diff.Normalize();
				projectile.velocity = diff;
				projectile.direction = (projectile.spriteDirection = ((projectile.velocity.X > 0f) ? 1 : -1));
				projectile.netUpdate = true;
				projectile.position = player.Center;
				projectile.position.Y -= 60;
			}
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.4f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.4f) / 255f);
			if (++projectile.frameCounter >= 12)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 5)
				{
					projectile.Kill();
				}
			}
			projectile.rotation = projectile.velocity.ToRotation();
			if (projectile.spriteDirection == -1)
			{
				projectile.position.X -= 59;
			}
			else
			{
				projectile.position.X += 7;
			}
			if (projectile.spriteDirection == -1)
			projectile.rotation += MathHelper.Pi;
			projectile.rotation = 0;
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
	}
}
