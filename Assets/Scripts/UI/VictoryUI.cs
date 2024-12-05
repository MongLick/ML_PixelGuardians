using UnityEngine;
using UnityEngine.UI;

public class VictoryUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Button gameEndButton;

	private void Awake()
	{
		Manager.UI.VictoryUI = this;
		gameObject.SetActive(false);
		gameEndButton.onClick.AddListener(GameEnd);
	}

	private void GameEnd()
	{
		Manager.Scene.LoadScene("TitleScene");
	}
}
