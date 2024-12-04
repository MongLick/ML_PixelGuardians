using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
	private enum ButtonAction { Sell, Spawn, Merge, None }

	[Header("Components")]
	[SerializeField] Button sellTowerButton;
	[SerializeField] Button spawnTowerButton;
	[SerializeField] Button mergeTowersButton;

	[Header("Tile Colors")]
	[SerializeField] Color sellTileColor;
	[SerializeField] Color spawnTileColor;
	[SerializeField] Color mergeTileColor;

	[Header("Specs")]
	private ButtonAction currentAction;

	private void Awake()
	{
		Manager.UI.ButtonHandler = this;
		sellTowerButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.Sell));
		spawnTowerButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.Spawn));
		mergeTowersButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.Merge));
	}

	private void HandleButtonClick(ButtonAction action)
	{
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
		}
	}

	private void ResetButtonAndTileColors()
	{
		Manager.UI.IsSellTower = false;
		Manager.UI.IsSpawnTower = false;
		Manager.UI.IsMergeTower = false;
		Manager.Game.DisableAllTileOverlays();
	}

	public void CurrentActionChange()
	{
		currentAction = ButtonAction.None;
	}
}
