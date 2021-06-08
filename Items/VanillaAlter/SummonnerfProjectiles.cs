using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.VanillaAlter
{
	public class SummonnerfProjectiles : GlobalProjectile
	{
		public override void SetDefaults(Projectile projectile)
		{
			if (projectile.type == ProjectileID.HornetStinger)
			{
				projectile.minion = true;
			}
			if (projectile.type == ProjectileID.ImpFireball)
			{
				projectile.minion = true;
			}
			if (projectile.type == ProjectileID.MiniRetinaLaser)
			{
				projectile.minion = true;
			}
			if (projectile.type == ProjectileID.PygmySpear)
			{
				projectile.minion = true;
			}
			if (projectile.type == ProjectileID.UFOLaser)
			{
				projectile.minion = true;
			}
			if (projectile.type == ProjectileID.MiniSharkron)
			{
				projectile.minion = true;
			}
		}
        public override void AI(Projectile projectile)
        {
			if (projectile.minion == true)
			{
				if (Main.LocalPlayer.GetModPlayer<FPPlayer>().summonnerf == true)
				{ projectile.damage = 4; }
			};
        }
    }
}