using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FPenumbra.Projectiles.PrototypeVile
{
	public class EnergyBlastEffect : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 10;
		}

		public override void SetDefaults() 
		{
			projectile.width = 125;
			projectile.height = 125;
			projectile.alpha = 50;
			projectile.hostile = false;
			projectile.friendly = false;
			projectile.extraUpdates = 3;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.scale = 0.80f;
		}

		public override void AI()
        {
			projectile.alpha += 40;
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.4f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.4f) / 255f);
			if (++projectile.frameCounter >= 11)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 10)
				{
					projectile.Kill();
				}
			}
			if (projectile.frame == 10)
			projectile.Kill();
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
	}
}
