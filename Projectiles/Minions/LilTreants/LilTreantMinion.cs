using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Projectiles.Minions.LilTreants
{

	public class LilTreantMinionBuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Soaring Sapling");
			Description.SetDefault("The small treants will protect you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ModContent.ProjectileType<LilTreantMinion>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}

	public class LilTreantItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treant's Acorn");
			Tooltip.SetDefault("Summons a soaring sapling to fight for you");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 8;
			item.knockBack = 2f;
			item.mana = 8;
			item.width = 34;
			item.height = 36;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item44;
			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<LilTreantMinionBuff>();
			item.shoot = ModContent.ProjectileType<LilTreantMinion>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			for (int i = 0; i < 7; i++)
			{
				int dust1 = Dust.NewDust(position, 0, 0, DustID.Grass, 0, 0);
				int dust2 = Dust.NewDust(position, 0, 0, DustID.t_LivingWood, 0, 0);
			}
			return true;
		}
	}

	public class LilTreantMinion : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Soaring Sapling");
			Main.projFrames[projectile.type] = 8;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public sealed override void SetDefaults() {
			projectile.width = 38;
			projectile.height = 38;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1f;
			projectile.penetrate = -1;
			projectile.aiStyle = 54;
			aiType = ProjectileID.Raven;
		}
		public override void AI()
		{
			Player player = Main.player[projectile.owner];

			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(ModContent.BuffType<LilTreantMinionBuff>());
			}
			if (player.HasBuff(ModContent.BuffType<LilTreantMinionBuff>()))
			{
				projectile.timeLeft = 2;
			}
		}
			#endregion
		public override bool? CanCutTiles() {
			return false;
		}

		public override bool MinionContactDamage() {
			return true;
		}
	}
}
