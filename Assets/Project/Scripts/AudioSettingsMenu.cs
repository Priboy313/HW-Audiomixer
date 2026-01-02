using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsMenu : MonoBehaviour
{
	[SerializeField] private Slider _sliderMaster;
	[SerializeField] private Slider _sliderMusic;
	[SerializeField] private Slider _sliderSound;
	[SerializeField] private Toggle _toggleMute;

	private IAudioService _audioService;

	public void Init(IAudioService audioService)
	{
		_audioService = audioService;

		_sliderMaster.value = _audioService.GetMasterVolume();
		_sliderMusic.value = _audioService.GetMusicVolume();
		_sliderSound.value = _audioService.GetSoundVolume();

		_sliderMaster.onValueChanged.RemoveAllListeners();
		_sliderMaster.onValueChanged.AddListener(OnMasterChanged);

		_sliderMusic.onValueChanged.RemoveAllListeners();
		_sliderMusic.onValueChanged.AddListener(OnMusicChanged);

		_sliderSound.onValueChanged.RemoveAllListeners();
		_sliderSound.onValueChanged.AddListener(OnSoundChanged);

		_toggleMute.onValueChanged.RemoveAllListeners();
		_toggleMute.onValueChanged.AddListener(OnMuteChanged);
	}

	private void OnMasterChanged(float value)
	{
		_audioService.SetMasterVolume(value);
	}

	private void OnMusicChanged(float value)
	{
		_audioService.SetMusicVolume(value);
	}

	private void OnSoundChanged(float value)
	{
		_audioService.SetSoundVolume(value);
	}

	private void OnMuteChanged(bool enabled)
	{
		_audioService.SetMute(enabled);
	}
}
