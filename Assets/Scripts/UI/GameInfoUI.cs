using UnityEngine;
using UnityEngine.UI;

public class GameInfoUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Button towerPrefabUIButton;
	[SerializeField] Button pauseUIButton;

	private void Awake()
	{
		Manager.UI.GameInfoUI = this;
		towerPrefabUIButton.onClick.AddListener(TowerPrefabUIActive);
		pauseUIButton.onClick.AddListener(PauseUIActive);
	}

	private void TowerPrefabUIActive()
	{
		Manager.Sound.UIPlaySFX();
		Manager.UI.TowerPrefabUI.gameObject.SetActive(true);
	}

	private void PauseUIActive()
	{
		Manager.Sound.UIPlaySFX();
		Time.timeScale = 0f;
		Manager.UI.PauseUI.gameObject.SetActive(true);
	}
}
