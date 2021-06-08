using FPenumbra.Items.PrototypeVile;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FPenumbra.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class VileLiquidatorHat : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("10% increased ranged damage" +
				"\n+5% increased ranged critical chance");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 22;
			item.value = 1200;
			item.rare = ItemRarityID.Orange;
			item.defense = 9;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<VileLiquidatorSuit>() && legs.type == ModContent.ItemType<VileLiquidatorGreaves>();
		}

		public override void UpdateEquip(Player player)
		{ 
			player.rangedDamage += 0.1f;
			player.rangedCrit += 5;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.nightVision = true;
			player.detectCreature = true;
			player.GetModPlayer<FPPlayer>().vileliquidator = true;
			player.setBonus = "Gain night vision and enemy detection" +
				"\nPress Liquidator Bolts Hotkey to fire homing bolts around you";
		}

		public override void ArmorSetShadows(Player player)
		{
			Lighting.AddLight(player.position, 0.35f, 0.1f, 0.5f);
			if (player.velocity.X >= 1 || player.velocity.Y >= 1)
			{
				for (int i = 0; i < 2; i++)
				{
					int dust = Dust.NewDust(player.position - player.velocity * 2, player.width, player.height, ModContent.DustType<Dusts.VileEnergyDust>());
					if (Main.rand.NextBool(2))
					{
						Main.dust[dust].scale = 1.5f;
						Main.dust[dust].velocity = -player.velocity / 20;
					}
					else
					{
						Main.dust[dust].scale = 0.8f;
						Main.dust[dust].velocity = -player.velocity / 20;
					}
				}
			}
		}
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<LiquidatorScrap>(), 15);
			recipe.AddIngredient(ItemID.Wire, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}