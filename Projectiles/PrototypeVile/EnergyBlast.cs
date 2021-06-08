using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FPenumbra.Projectiles.PrototypeVile
{
	public class EnergyBlast : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.knockBack = 0;
			projectile.width = 1;
			projectile.height = 1;
			projectile.alpha = 0;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.extraUpdates = 3;
			projectile.penetrate = -1;
			projectile.timeLeft = 3;
			projectile.scale = 0.85f;
		}

		public override void AI()
		{
			{
				projectile.rotation += projectile.velocity.Y * 0.01f;
				projectile.velocity.Y += 0.01f;
				if (projectile.timeLeft == 1)
				{
					projectile.tileCollide = false;
					projectile.alpha = 255;
					projectile.position = projectile.Center;
					projectile.width = 125;
					projectile.height = 125;
					projectile.Center = projectile.position;
					projectile.damage = 50;
				}
				if (projectile.localAI[0] == 0f)
				{
					AdjustMagnitude(ref projectile.velocity);
					projectile.localAI[0] = 1f;
				}
				Vector2 move = Vector2.Zero;
			}
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
			Main.PlaySound(SoundLoader.customSoundType, projectile.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/EnergyBlast"));
			Projectile.NewProjectile(new Vector2(projectile.position.X + 42, projectile.position.Y + 42), new Vector2(0), ModContent.ProjectileType<Projectiles.PrototypeVile.EnergyBlastEffect>(), 0, 0, Main.myPlayer, Main.myPlayer);
			// Fire Dust spawn
			for (int i = 0; i < 16; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.VileEnergyDust>(), 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].scale = 1.85f;
				Main.dust[dustIndex].noGravity = false;
				Main.dust[dustIndex].velocity *= 4f;
				dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.VileEnergyDust>(), 0f, 0f, 100, default(Color), 1f);
				Main.dust[dustIndex].scale = 1.1f;
				Main.dust[dustIndex].noGravity = false;
				Main.dust[dustIndex].velocity *= 2f;
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
	}
}
