using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
	private enum ButtonAction { Sell, Spawn, Merge, Upgrade, None }

	[Header("Components")]
	[SerializeField] Button sellTowerButton;
	[SerializeField] Button spawnTowerButton;
	[SerializeField] Button mergeTowersButton;
	[SerializeField] Button upgradeButton;

	[Header("Tile Colors")]
	[SerializeField] Color sellTileColor;
	[SerializeField] Color spawnTileColor;
	[SerializeField] Color mergeTileColor;

	[Header("ButtonAction")]
	private ButtonAction currentAction;

	private void Awake()
	{
		Manager.UI.TowerUI = this;
		sellTowerButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.Sell));
		spawnTowerButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.Spawn));
		mergeTowersButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.Merge));
		upgradeButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.Upgrade));
	}

	private void HandleButtonClick(ButtonAction action)
	{
		Manager.Sound.UIPlaySFX();

		if (currentAction == action)
		{
			ResetButtonAndTileColors();
			return;
		}

		ResetButtonAndTileColors();
		currentAction = action;
		switch (action)
		{
			case ButtonAction.Sell:
				Manager.UI.IsSellTower = true;
				Manager.Game.ChangeTileColors(sellTileColor);
				break;
			case ButtonAction.Spawn:
				Manager.UI.IsSpawnTower = true;
				Manager.Game.ChangeTileColors(spawnTileColor);
				break;
			case ButtonAction.Merge:
				Manager.UI.IsMergeTower = true;
				Manager.Game.ChangeTileColors(mergeTileColor);
				break;
			case ButtonAction.Upgrade:
				Manager.UI.UpgradeUI.gameObject.SetActive(true);
				break;
		}
	}

	private void ResetButtonAndTileColors()
	{
		Manager.UI.IsSellTower = false;
		Manager.UI.IsSpawnTower = false;
		Manager.UI.IsMergeTower = false;
		Manager.UI.UpgradeUI.gameObject.SetActive(false);
		Manager.Game.DisableAllTileOverlays();
	}

	public void CurrentActionChange()
	{
		currentAction = ButtonAction.None;
	}
}
