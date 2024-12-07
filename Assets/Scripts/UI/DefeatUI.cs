using UnityEngine;
using UnityEngine.UI;

public class DefeatUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Button gameEndButton;

	private void Awake()
	{
		Manager.UI.DefeatUI = this;
		gameObject.SetActive(false);
		gameEndButton.onClick.AddListener(GameEnd);
	}

	private void GameEnd()
	{
		Manager.Sound.UIPlaySFX();
		Time.timeScale = 1f;
		gameObject.SetActive(false);
		Manager.Scene.LoadScene("TitleScene");
	}
}
