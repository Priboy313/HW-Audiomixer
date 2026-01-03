public interface IAudioService
{
	public void SetVolume(AudioGroup group, float volume);

	public float GetVolume(AudioGroup group);

	public void SetMute(bool enabled);
}
