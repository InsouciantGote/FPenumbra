using FPenumbra;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FPenumbra.Items
{
	public class SeedsOfDeterrence : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Seeds of Deterrence");
			Tooltip.SetDefault("Lets your world spawn treants in the forest" +
				"\nSpawns corrupted/crimson and hallowed treants in hardmode");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 1;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}
		public override bool CanUseItem(Player player)
		{
			return !FPWorld.downedseedsofdeterrence;
		}
		public override bool UseItem(Player player)
		{
			if (!FPWorld.downedseedsofdeterrence)
			{
				Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/TreantSeedsActive"));
				FPWorld.downedseedsofdeterrence = true;
				Main.NewText("The treants have awoken in your world!", 15, 225, 15);
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.SendData(MessageID.WorldData);
				}
			}
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 50);
			recipe.AddIngredient(ItemID.Acorn, 20);
			recipe.AddIngredient(ItemID.FallenStar, 2);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if (FPWorld.downedseedsofdeterrence)
			{
				var line1 = new TooltipLine(mod, "SeedsOfDeterrence", "Effects have been applied and can no longer be reversed")
				{
					overrideColor = new Color(217, 19, 19)
				};
				tooltips.Add(line1);
				tooltips.RemoveAll(l => l.Name.StartsWith("Effects"));
			}
			else
			{
				var line1 = new TooltipLine(mod, "SeedsOfDeterrence", "Effects cannot be reversed once used")
				{
					overrideColor = new Color(217, 19, 19)
				};
				tooltips.Add(line1);
				tooltips.RemoveAll(l => l.Name.StartsWith("Effects"));
			}
		}
	}
}