using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace FPenumbra
{
	public class FPWorld : ModWorld
	{
		public static bool downedAlphaFrostjawHead;
		public static bool downedPrototypeVile;
		public static bool downedseedsofdeterrence;

		public override void Initialize() {
			downedAlphaFrostjawHead = false;
			downedPrototypeVile = false;
			downedseedsofdeterrence = false;
		}

		public override TagCompound Save() {
			var downed = new List<string>();
			if (downedAlphaFrostjawHead) {
				downed.Add("AlphaFrostjawHead"); }
			if (downedPrototypeVile)
			{
				downed.Add("PrototypeVile");
			}
			if (downedseedsofdeterrence) {
				downed.Add("SeedsOfDeterrance");
			}

			return new TagCompound {
				["downed"] = downed,
			};
		}

		public override void Load(TagCompound tag) {
			var downed = tag.GetList<string>("downed");
			downedAlphaFrostjawHead = downed.Contains("AlphaFrostjawHead");
			downedPrototypeVile = downed.Contains("PrototypeVile");
			downedseedsofdeterrence = downed.Contains("SeedsOfDeterrance");
		}

		public override void LoadLegacy(BinaryReader reader) {
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0) {
				BitsByte flags = reader.ReadByte();
				downedAlphaFrostjawHead = flags[0];
				downedPrototypeVile = flags[1];
				downedseedsofdeterrence = flags[2];
			}
			else {
				mod.Logger.WarnFormat("FPenumbra: Unknown loadVersion: {0}", loadVersion);
			}
		}

		public override void NetSend(BinaryWriter writer)
		{
			var flags = new BitsByte();
			flags[0] = downedAlphaFrostjawHead;
			flags[1] = downedPrototypeVile;
			flags[2] = downedseedsofdeterrence;
			writer.Write(flags);
		}


		public override void NetReceive(BinaryReader reader) {
			BitsByte flags = reader.ReadByte();
			downedAlphaFrostjawHead = flags[0];
			downedPrototypeVile = flags[1];
			downedseedsofdeterrence = flags[1];
		}
	}
}
