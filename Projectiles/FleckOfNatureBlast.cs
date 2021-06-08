using FPenumbra.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles
{
	public class FleckOfNatureBlast : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fleck of Nature Blast");
		}

		public override void SetDefaults()
		{
			projectile.width = 60;
			projectile.height = 60;
			projectile.alpha = 0;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.melee = false;
			projectile.magic = true;
			projectile.timeLeft = 180;
			projectile.penetrate = -1;
			projectile.extraUpdates = 3;
			drawOriginOffsetY = 2;

		}

		public override void AI()
		{
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.0f) / 255f, ((255 - projectile.alpha) * 0.5f) / 255f, ((255 - projectile.alpha) * 5f) / 255f);
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
			}
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<FleckOfNature2>());
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
