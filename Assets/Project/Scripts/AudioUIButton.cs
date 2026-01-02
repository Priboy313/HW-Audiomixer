using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AudioUIButton : MonoBehaviour
{
	[SerializeField] AudioSource _audioSource;
	[SerializeField] AudioClip _audioClip;

	private Button _button;

	private void Awake()
	{
		bool hasError = false;

		if (_audioSource == null)
		{
			Debug.LogError("AudioSource not set!", this); ;
			hasError = true;
		}

		if (_audioClip == null)
		{
			Debug.LogError("Audioclip not set!", this); ;
			hasError = true;
		}

		if (hasError)
		{
			enabled = false;
			return;
		}

		_button = GetComponent<Button>();
	}

	private void OnEnable()
	{
		_button.onClick.AddListener(OnButtonClick);
	}

	private void OnDisable()
	{
		_button.onClick.RemoveListener(OnButtonClick);
	}

	private void OnButtonClick()
	{
		_audioSource.PlayOneShot(_audioClip);
	}
}
