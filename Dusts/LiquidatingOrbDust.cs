using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace FPenumbra.Dusts
{
	public class LiquidatingOrbDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noLight = false;
			dust.color = new Color(200, 255, 200);
			dust.scale = 0.75f;
			dust.noGravity = true;
			dust.velocity /= 1f;
			dust.alpha = 25;
		}

		public override bool Update(Dust dust) {
			dust.rotation += dust.velocity.X;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.15f, 0.02f, 0.15f);
			dust.scale -= 0.03f;
			if (dust.scale < 0.03f) {
				dust.active = false;
			}
			return false;
		}
		public override Color? GetAlpha(Dust dust, Color lightColor)
			=> new Color(160, 50, 200, 25);
	}
}