using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsMenu : MonoBehaviour, IDisposable
{
	[SerializeField] private Slider _sliderMaster;
	[SerializeField] private Slider _sliderMusic;
	[SerializeField] private Slider _sliderSound;
	[SerializeField] private Toggle _toggleMute;

	private IAudioService _audioService;

	public void Init(IAudioService audioService)
	{
		_audioService = audioService;

		InitSlider(_sliderMaster, AudioGroup.Master);
		InitSlider(_sliderMusic, AudioGroup.Music);
		InitSlider(_sliderSound, AudioGroup.Sound);

		_toggleMute.onValueChanged.RemoveAllListeners();
		_toggleMute.onValueChanged.AddListener(OnMuteChanged);
	}

	private void InitSlider(Slider slider, AudioGroup group)
	{
		slider.value = _audioService.GetVolume(group);

		slider.onValueChanged.RemoveAllListeners();

		slider.onValueChanged.AddListener((volume) =>
		{
			_audioService.SetVolume(group, volume);
		});
	}

	public void Dispose()
	{
		_sliderMaster.onValueChanged.RemoveAllListeners();
		_sliderMusic.onValueChanged.RemoveAllListeners();
		_sliderSound.onValueChanged.RemoveAllListeners();
		_toggleMute.onValueChanged.RemoveAllListeners();
	}

	private void OnMuteChanged(bool enabled)
	{
		_audioService.SetMute(enabled);
	}

	private void OnDestroy()
	{
		Dispose();
	}
}
