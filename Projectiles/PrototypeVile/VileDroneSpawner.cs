using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles.PrototypeVile
{
	public class VileDroneSpawner : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults() 
		{
			projectile.width = 0;
			projectile.height = 0;
			projectile.alpha = 0;
			projectile.friendly = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.ranged = true;
			projectile.extraUpdates = 3;
			projectile.scale = 1.2f;
			projectile.timeLeft = 120;
			drawOriginOffsetY = 2;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.15f) / 255f, ((255 - projectile.alpha) * 0.02f) / 255f, ((255 - projectile.alpha) * 0.15f) / 255f);
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.LiquidatingOrbDust>());
				if (Main.rand.NextBool(2))
				{
					Main.dust[dust].scale = 0.9f;
					Main.dust[dust].velocity *= 0;
				}
				else
				{
					Main.dust[dust].scale = 0.7f;
					Main.dust[dust].velocity *= 0;
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item8, projectile.Center);
			NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, mod.NPCType("VileDrone"));
			for (int i = 0; i < 16; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.VileEnergyDust>());
				if (Main.rand.NextBool(2))
				{
					Main.dust[dust].scale = 1.9f;
					Main.dust[dust].velocity *= 2;
				}
				else
				{
					Main.dust[dust].scale = 0.8f;
					Main.dust[dust].velocity *= 1.2f;
				}
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
	}
}