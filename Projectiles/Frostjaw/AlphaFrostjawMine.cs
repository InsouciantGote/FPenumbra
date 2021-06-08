using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles.Frostjaw
{
	public class AlphaFrostjawMine : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.npcProj = true;
			projectile.width = 22;
			projectile.height = 30;
			projectile.alpha = 0;
			projectile.hostile = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.ranged = true;
			projectile.maxPenetrate = 1;
			projectile.timeLeft = 3600;
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
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.7f) / 255f, ((255 - projectile.alpha) * 0.7f) / 255f);
			if (projectile.alpha > 0)
			{
				projectile.alpha = 0;
			}
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			if (Main.rand.NextBool(10))
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.FrostjawDust>());
				Main.dust[dust].velocity /= 2f;
			}
			projectile.rotation = 0;
			if (!NPC.AnyNPCs(ModContent.NPCType<NPCs.Frostjaw.AlphaFrostjawHead>()))
			{ 
				projectile.timeLeft = 0;
			}
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
			if (projectile.soundDelay == 0)
			{
				float num1 = 99999f;
				if (num1 < 99999)
					num1 = 99999f;
				projectile.soundDelay = (int)num1;
				Main.PlaySound(SoundID.Shatter, projectile.Center);
			};
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.FrostjawDust>());
			}
			for (int i = 0; i < 8; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.FrostjawShards>());
			}
		}
		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			projectile.timeLeft = 0;
			target.AddBuff(BuffID.Frozen, 90);
			target.AddBuff(BuffID.Frostburn, 90);
			Player player = Main.LocalPlayer;
			if (player.ZoneSnow == false)
			{
				target.AddBuff(BuffID.Frozen, 150);
				target.AddBuff(BuffID.Frostburn, 150);
			}
		}
	}
}
