using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FPenumbra.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class EnchantedHat : ModItem
	{
		public override void SetStaticDefaults() {
            Tooltip.SetDefault("5% increased magic damage" +
				"\nIncreases mana by 40");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 22;
			item.value = 1200;
			item.rare = ItemRarityID.Blue;
			item.defense = 2;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<EnchantedBreastplate>() && legs.type == ModContent.ItemType<EnchantedGreaves>();
		}

		public override void UpdateEquip(Player player)
		{ 
			player.magicDamage += 0.05f;
			player.statManaMax2 += 40;
		}

		public override void UpdateArmorSet(Player player)
		{
			if (!Main.LocalPlayer.HasBuff(ModContent.BuffType<Buffs.LivingRegenCooldown>()))
			{
				player.lifeRegen += 4;
			}
			player.GetModPlayer<FPPlayer>().livingregen = true;
			player.setBonus = "Gain living regen which grants you quicker life regen" +
				"\nWhen hurt, it is disabled for 10 seconds.";
		}
		public override void ArmorSetShadows(Player player)
		{
			if (Main.rand.NextBool(3))
			{
				if (player.velocity.X >= 1 || player.velocity.Y >= 1)
					{
					int dust = Dust.NewDust(player.position - player.velocity * 2, player.width, player.height, ModContent.DustType<Dusts.EnchantedDust>());
				}
			}
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EnchantedWood>(), 20);
			recipe.AddTile(TileID.LivingLoom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}