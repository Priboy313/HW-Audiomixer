using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour, IAudioService
{
	[SerializeField] private AudioMixer _audioMixer;

	private const string MasterVolume = "MasterVolume";
	private const string MusicVolume = "MusicVolume";
	private const string SoundVolume = "SoundVolume";

	private float _volumeCurrent = 1f;
	private float _volumeMute = -80f;

	public void SetMasterVolume(float volume)
	{
		SetMixerParam(MasterVolume, volume);
	}

	public void SetMusicVolume(float volume)
	{
		SetMixerParam(MusicVolume, volume);
	}

	public void SetSoundVolume(float volume)
	{
		SetMixerParam(SoundVolume, volume);
	}

	public void SetMute(bool enabled)
	{
		if (enabled)
		{
			_volumeCurrent = GetMixerParam(MasterVolume);
			SetMasterVolume(_volumeMute);
		}
		else
		{
			SetMasterVolume(_volumeCurrent);
		}
	}

	public float GetMasterVolume()
	{
		return GetMixerParam(MasterVolume);
	}

	public float GetMusicVolume()
	{
		return GetMixerParam(MusicVolume);
	}

	public float GetSoundVolume()
	{
		return GetMixerParam(SoundVolume);
	}

	public bool IsMuted()
	{
		return GetMixerParam(MasterVolume) > _volumeMute;
	}

	private void SetMixerParam(string name, float volume)
	{
		// from [0, 1] float volume to mixer db
		float db = volume <= 0.001f ? _volumeMute : Mathf.Log10(volume) * 20;
		_audioMixer.SetFloat(name, db);
	}

	private float GetMixerParam(string name)
	{
		_audioMixer.GetFloat(name, out float db);
		
		// from  mixer db to [0, 1] float
		return Mathf.Pow(10, db / 20);
	}
}
