using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.NPCs
{
	public class FPNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public bool energycleave;

		public override void ResetEffects(NPC npc)
		{
			energycleave = false;
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (energycleave)
			{
				if (Main.rand.NextBool(7))
				{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.VileEnergyDust>());
					Main.dust[dust].scale = 1.4f;
					Main.dust[dust].velocity *= 2f;
				}
			}
		}
        public override void HitEffect(NPC npc, int hitDirection, double damage)
        {
			if (energycleave && npc.life <= 0)
			{
				Projectile.NewProjectile(npc.Center, new Vector2(0), ModContent.ProjectileType<Projectiles.PrototypeVile.EnergyBlast>(), 72, 0, Main.myPlayer, Main.myPlayer);
			}
			}
    }
}
