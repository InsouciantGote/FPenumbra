using System.ComponentModel;
using Terraria.ModLoader.Config;


namespace FPenumbra
{
	public class FPenumbraConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[Label("Low Health SFX")]
		[Tooltip("Enables/disables sounds that play whenever you reach low health.")]
		[DefaultValue(true)]
		public bool lowhealthsfx { get; set; }

		[Label("Penumbra's Summoner Alteration")]
		[Tooltip("Enables/disables summoner damage mechanic of this mod.")]
		[DefaultValue(true)]
		public bool summonerfconfig { get; set; }

		[Label("Space Gun Nerf")]
		[Tooltip("Enables/disables Space Gun's nerf stats (not recommended for regular gameplay unless there's another nerf of that weapon from another mod)." +
			"\nYou must save and exit your world for this setting to work.")]
		[DefaultValue(true)]
		public bool spacegunnerf { get; set; }
	}
}
