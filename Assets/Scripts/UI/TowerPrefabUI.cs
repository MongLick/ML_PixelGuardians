using UnityEngine;
using UnityEngine.UI;

public class TowerPrefabUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Button activeButton;

	private void Awake()
	{
		Manager.UI.TowerPrefabUI = this;
		gameObject.SetActive(false);
		activeButton.onClick.AddListener(TowerPrefabUIActive);
	}

	private void TowerPrefabUIActive()
	{
		gameObject.SetActive(false);
	}
}
