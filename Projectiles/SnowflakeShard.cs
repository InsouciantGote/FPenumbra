using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles
{
	public class SnowflakeShard : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snowflake Shard");
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
			projectile.timeLeft = 360;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.5f) / 255f, ((255 - projectile.alpha) * 0.55f) / 255f, ((255 - projectile.alpha) * 0.6f) / 255f);
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
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
				int dust1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.FrostjawDust>());
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
	}
}
