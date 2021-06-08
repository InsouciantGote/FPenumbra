using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.Localization;

namespace FPenumbra.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MeteorHood : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("9% increased melee damage");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 22;
			item.value = 4500;
			item.rare = ItemRarityID.Blue;
			item.defense = 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemID.MeteorSuit && legs.type == ItemID.MeteorLeggings;
		}

		public override void UpdateEquip(Player player)
		{ 
			player.meleeDamage += 0.09f; 
		}

		public override void UpdateArmorSet(Player player)
		{
			player.GetModPlayer<FPPlayer>().meteorhood = true;
			player.setBonus = "+30% Phaseblade damage and sets enemies on fire";
		}
		public override void ArmorSetShadows(Player player)
		{
			if (player.velocity.X >= 1 || player.velocity.Y >= 1)
			{
				Dust.NewDust(player.position - player.velocity * 2, player.width, player.height, ModContent.DustType<Dusts.MeteorDust>());
				Dust.NewDust(player.position - player.velocity * 2, player.width, player.height, ModContent.DustType<Dusts.MeteorDust>());
			}
			if (player.velocity.X <= -1 || player.velocity.Y <= -1)
			{
				Dust.NewDust(player.position - player.velocity * 2, player.width, player.height, ModContent.DustType<Dusts.MeteorDust>());
				Dust.NewDust(player.position - player.velocity * 2, player.width, player.height, ModContent.DustType<Dusts.MeteorDust>());
			}
		}
		public override bool DrawHead()
		{
			return false;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe.AddIngredient(ItemID.Silk, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}