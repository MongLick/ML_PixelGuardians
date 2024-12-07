using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Button ResumeButton;
	[SerializeField] Button ExitButton;
	[SerializeField] Button SoundButton;

	private void Awake()
	{
		Manager.UI.PauseUI = this;
		gameObject.SetActive(false);
		ResumeButton.onClick.AddListener(GameResume);
		ExitButton.onClick.AddListener(GameExit);
		SoundButton.onClick.AddListener(SoundSetting);
	}

	private void GameResume()
	{
		Manager.Sound.UIPlaySFX();
		Time.timeScale = 1f;
		gameObject.SetActive(false);
	}

	private void GameExit()
	{
		Manager.Sound.UIPlaySFX();
		Time.timeScale = 1f;
		Manager.Game.GameOver();
		Manager.Scene.LoadScene("TitleScene");
	}

	private void SoundSetting()
	{
		Manager.Sound.UIPlaySFX();
		gameObject.SetActive(false);
		Manager.UI.SoundUI.gameObject.SetActive(true);
	}
}
