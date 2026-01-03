using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour, IAudioService
{
	[SerializeField] private AudioMixer _audioMixer;

	private float _dbCurrent = 0f;
	private float _dbMute = -80f;

	public void SetVolume(AudioGroup group, float volume)
	{
		string param = GetParamName(group);

		float db = volume <= 0.001f ? _dbMute : Mathf.Log10(volume) * 20;
		_audioMixer.SetFloat(param, db);
	}

	public float GetVolume(AudioGroup group)
	{
		string param = GetParamName(group);

		if (_audioMixer.GetFloat(param, out float db))
		{
			return Mathf.Pow(10, db / 20);
		}

		return _dbCurrent;
	}
	
	public void SetMute(bool enabled)
	{
		if (enabled)
		{
			_dbCurrent = GetVolume(AudioGroup.Master);
			SetVolume(AudioGroup.Master, _dbMute);
		}
		else
		{
			SetVolume(AudioGroup.Master, _dbCurrent);
		}
	}

	private string GetParamName(AudioGroup group)
	{
		return group switch
		{
			AudioGroup.Master => "Master",
			AudioGroup.Music => "Music",
			AudioGroup.Sound => "Sound",
			_ => "Master"
		};
	}
}
