using UnityEngine;

public interface IAudioService
{
	public void SetMasterVolume(float volume);
	public void SetMusicVolume(float volume);
	public void SetSoundVolume(float volume);
	public void SetMute(bool enabled);

	public float GetMasterVolume();
	public float GetMusicVolume();
	public float GetSoundVolume();
	public bool IsMuted();
}
