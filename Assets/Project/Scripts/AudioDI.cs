using UnityEngine;

public class AudioDI : MonoBehaviour
{
	[SerializeField] private AudioHandler _audioHandler;
	[SerializeField] private AudioSettingsMenu _audioSettingsMenu;

	private void Awake()
	{
		_audioSettingsMenu.Init(_audioHandler);
	}
}
