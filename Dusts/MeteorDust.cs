using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace FPenumbra.Dusts
{
	public class MeteorDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noLight = true;
			dust.scale = 1.7f;
			dust.noGravity = true;
			dust.velocity /= 6f;
			dust.alpha = 0;
		}

		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			dust.scale -= 0.05f;
			if (dust.scale <= 0.05f) {
				dust.active = false;
			}
			return false;
		}
		public override Color? GetAlpha(Dust dust, Color lightColor)
			=> new Color(255, 255, 255);
	}
}