using UnityEngine;
using UnityEngine.UI;

public class SoundUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Button bgmOnButton;
	[SerializeField] Button bgmOffButton;
	[SerializeField] Button sfxOnButton;
	[SerializeField] Button sfxOffButton;
	[SerializeField] Button backButton;
	[SerializeField] Slider bgmSlider;
	[SerializeField] Slider sfxSlider;

	private void Awake()
	{
		Manager.UI.SoundUI = this;
		gameObject.SetActive(false);
		bgmOnButton.onClick.AddListener(BGMOn);
		bgmOffButton.onClick.AddListener(BGMOff);
		sfxOnButton.onClick.AddListener(SFXOn);
		sfxOffButton.onClick.AddListener(SFXOff);
		backButton.onClick.AddListener(SoundUIBack);
		bgmSlider.onValueChanged.AddListener(BGMChanged);
		sfxSlider.onValueChanged.AddListener(SFXChanged);
	}

	private void Start()
	{
		bgmSlider.value = Manager.Sound.BGMVolme;
		sfxSlider.value = Manager.Sound.SFXVolme;
	}

	private void BGMOn()
	{
		Manager.Sound.UIPlaySFX();
		BGMChanged(0.2f);
		bgmSlider.value = 0.2f;
	}

	private void BGMOff()
	{
		Manager.Sound.UIPlaySFX();
		BGMChanged(0f);
		bgmSlider.value = 0f;
	}

	private void SFXOn()
	{
		Manager.Sound.UIPlaySFX();
		SFXChanged(0.5f);
		sfxSlider.value = 0.5f;
	}

	private void SFXOff()
	{
		Manager.Sound.UIPlaySFX();
		SFXChanged(0f);
		sfxSlider.value = 0f;
	}

	private void SoundUIBack()
	{
		Manager.Sound.UIPlaySFX();
		gameObject.SetActive(false);
		Manager.UI.PauseUI.gameObject.SetActive(true);
	}

	private void BGMChanged(float value)
	{
		Manager.Sound.BGMVolme = value;
	}

	private void SFXChanged(float value)
	{
		Manager.Sound.SFXVolme = value;
	}
}
