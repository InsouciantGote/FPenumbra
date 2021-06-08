using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace FPenumbra.Dusts
{
	public class CryoDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noLight = true;
			dust.color = new Color(60, 255, 255);
			dust.scale = 1f;
			dust.noGravity = true;
			dust.velocity /= 0.7f;
			dust.alpha = 100;
		}

		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.05f, 0.15f, 0.2f);
			dust.scale -= 0.03f;
			if (dust.scale < 0.5f) {
				dust.active = false;
			}
			return false;
		}
		public override Color? GetAlpha(Dust dust, Color lightColor)
			=> new Color(60, 255, 255, 25);
	}
}