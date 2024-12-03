using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
	private enum ButtonAction{Sell, Spawn, Merge}

	[Header("Components")]
	[SerializeField] Button sellTowerButton;
	[SerializeField] Button spawnTowerButton;
	[SerializeField] Button mergeTowersButton;

	[Header("Tile Colors")]
	[SerializeField] Color sellTileColor;
	[SerializeField] Color spawnTileColor;
	[SerializeField] Color mergeTileColor;

	private void Awake()
	{
		sellTowerButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.Sell));
		spawnTowerButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.Spawn));
		mergeTowersButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.Merge));
	}

	private void HandleButtonClick(ButtonAction action)
	{
		if (IsSameActionSelected(action))
		{
			ResetButtonAndTileColors();
		}
		else
		{
			ResetButtons();

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
	}

	private bool IsSameActionSelected(ButtonAction action)
	{
		return (action == ButtonAction.Sell && Manager.UI.IsSellTower) ||
			   (action == ButtonAction.Spawn && Manager.UI.IsSpawnTower) ||
			   (action == ButtonAction.Merge && Manager.UI.IsMergeTower);
	}

	private void ResetButtonAndTileColors()
	{
		ResetButtons();
		Manager.Game.DisableAllTileOverlays();
	}

	private void ResetButtons()
	{
		Manager.UI.IsSellTower = false;
		Manager.UI.IsSpawnTower = false;
		Manager.UI.IsMergeTower = false;
	}
}
