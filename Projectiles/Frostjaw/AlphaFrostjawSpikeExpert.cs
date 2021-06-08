using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles.Frostjaw
{
	public class AlphaFrostjawSpikeExpert : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alpha Frostjaw Spike");
		}

		public override void SetDefaults()
		{
			projectile.npcProj = true;
			projectile.width = 30;
			projectile.height = 22;
			projectile.alpha = 0;
			projectile.hostile = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.ranged = true;
			projectile.extraUpdates = 3;
		}

		public override void AI()
		{
			{
				if (projectile.soundDelay == 0)
				{
					float num1 = 99999f;
					if (num1 < 99999)
						num1 = 99999f;
					projectile.soundDelay = (int)num1;
					Main.PlaySound(SoundID.Item30, projectile.Center);
				}
			}
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
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
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item27, projectile.Center);
			for (int i = 0; i < 5; i++)
			{
				int dust1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.FrostjawDust>());
			}
			for (int i = 0; i < 8; i++)
			{
				int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.FrostjawShards>());
				Main.dust[dust2].noGravity = false;
			}
		}
		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 90);
			Player player = Main.LocalPlayer;
			if (player.ZoneSnow == false)
			{
				target.AddBuff(BuffID.Frostburn, 150);
			}
		}
	}
}
