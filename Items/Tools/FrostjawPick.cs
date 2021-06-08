using FPenumbra.Items.Frostjaw;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FPenumbra.Items.Tools
{
	public class FrostjawPick : ModItem
	{

		public override void SetDefaults() {
			item.damage = 8;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 18;
			item.useAnimation = 18;
			item.pick = 59;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2;
			item.value = 7500;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<FrostjawTooth>(), 2);
			recipe.AddIngredient(ItemID.GoldBar, 5);
			recipe.AddIngredient(ItemID.SnowBlock, 15);
			recipe.AddIngredient(ItemID.IceBlock, 15);
			recipe.AddTile(TileID.IceMachine);
			recipe.SetResult(this);
			recipe.AddRecipe();
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ModContent.ItemType<FrostjawTooth>(), 2);
			recipe2.AddIngredient(ItemID.PlatinumBar, 5);
			recipe2.AddIngredient(ItemID.SnowBlock, 15);
			recipe2.AddIngredient(ItemID.IceBlock, 15);
			recipe2.AddTile(TileID.IceMachine);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.FrostjawDust>());
			}
		}
	}
}