using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace FPenumbra.Dusts
{
	public class VileEnergyDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noLight = false;
			dust.scale = 0.85f;
			dust.noGravity = false;
			dust.velocity /= 1.2f;
			dust.alpha = 75;
		}

		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation = dust.velocity.ToRotation();
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.35f, 0.1f, 0.5f);
			dust.scale -= 0.04f;
			if (dust.scale < 0.001f) {
				dust.active = false;
			}
			if (dust.alpha > 0)
			{
				dust.alpha -= 15;
			}
			return false;
		}
		public override Color? GetAlpha(Dust dust, Color lightColor)
			=> new Color(160, 50, 200, 25);
	}
}