using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FPenumbra.Projectiles
{
	public class LeafDaggerLeaf : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Leaf");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.damage = 6;
			projectile.width = 32;
			projectile.height = 16;
			projectile.alpha = 50;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.melee = true;
			projectile.timeLeft = 60;
			projectile.penetrate = 1;
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
				Main.PlaySound(SoundID.Item8, projectile.Center);
			};
			if (++projectile.frameCounter >= 5)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
				{
					projectile.frame = 0;
				}
			}
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			projectile.velocity.Y = 0;
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
			for (int i = 0; i < 7; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.EnchantedDust>());
			}
		}
	}
}
