using FPenumbra.Items.Frostjaw;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Weapons
{
	public class FrostjawBlade : ModItem
	{

		public override void SetDefaults() {
			item.damage = 13;
			item.crit = 5;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3;
			item.value = 6500;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<FrostjawTooth>(), 3);
			recipe.AddIngredient(ItemID.SnowBlock, 10);
			recipe.AddIngredient(ItemID.IceBlock, 10);
			recipe.AddTile(TileID.IceMachine);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.FrostjawDust>());
			}
		}
	}
}