using Microsoft.Xna.Framework.Audio;
using Terraria.ModLoader;

namespace FPenumbra.Sounds.Custom
{
	public class Heartbeat : ModSound
	{
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type) {
			// By creating a new instance, this ModSound allows for overlapping sounds. Non-ModSound behavior is to restart the sound, only permitting 1 instance.
			soundInstance = sound.CreateInstance();
			soundInstance.Volume = volume * 0.85f;
			soundInstance.Pan = pan;
			soundInstance.Pitch = 0f;
			return soundInstance;
		}
	}
}
