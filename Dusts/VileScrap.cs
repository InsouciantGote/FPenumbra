using Terraria;
using Terraria.ModLoader;


namespace FPenumbra.Dusts
{
	public class VileScrap : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noLight = false;
			dust.scale = 1.5f;
			dust.noGravity = false;
			dust.velocity /= 0.8f;
			dust.alpha = 0;
			updateType = 33;
		}

		public override bool Update(Dust dust) {
			dust.velocity *= 0.5f;
			dust.velocity.Y += 1f;
			dust.noGravity = false;
			dust.position += dust.velocity;
			dust.scale -= 0.03f;
			if (dust.scale < 0.5f) {
				dust.active = false;
				dust.noGravity = false;
			}
			return false;
		}
	}
}