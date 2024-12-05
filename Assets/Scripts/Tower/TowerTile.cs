using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerTile : MonoBehaviour, IPointerClickHandler
{
	[Header("Components")]
	[SerializeField] TowerSpawner towerSpawner;
	[SerializeField] Image overlayImage;
	[SerializeField] Tower currentTower;
	public Tower CurrentTower { get { return currentTower; } set { currentTower = value; } }
	[SerializeField] Camera mainCamera;

	[Header("Specs")]
	private const int BaseSellCost = 50;
	private const int SellCostPerLevel = 30;
	private Ray ray;
	private RaycastHit hit;
	private string towerName;
	public string TowerName { get { return towerName; } set { towerName = value; } }
	private bool isTowerPresent;

	private void Awake()
	{
		mainCamera = Camera.main;
	}

	private void OnEnable()
	{
		towerSpawner = FindObjectOfType<TowerSpawner>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (Manager.UI.IsSellTower && isTowerPresent)
		{
			SellTower();
		}
		else if (Manager.UI.IsSpawnTower && !isTowerPresent)
		{
			HandleSpawnTower(eventData);
		}
		else if (Manager.UI.IsMergeTower && isTowerPresent)
		{
			MergeTower();
		}

		Manager.Game.DisableAllTileOverlays();
	}

	private void HandleSpawnTower(PointerEventData eventData)
	{
		ray = mainCamera.ScreenPointToRay(eventData.position);
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			towerSpawner.SpawnTower(hit.transform, 1);
			Manager.UI.IsSpawnTower = false;
		}
	}

	public void ChangeColor(Color color)
	{
		if ((Manager.UI.IsSellTower && isTowerPresent) ||
			(Manager.UI.IsSpawnTower && !isTowerPresent) ||
			(Manager.UI.IsMergeTower && isTowerPresent))
		{
			overlayImage.gameObject.SetActive(true);
			overlayImage.color = color;
		}
	}

	public void DisableImage()
	{
		overlayImage.gameObject.SetActive(false);
	}

	private void SellTower()
	{
		if (currentTower == null) return;

		GameObject activeTower = currentTower.TowerPrefabs.Find(tower => tower.activeSelf);
		if (activeTower != null)
		{
			int sellCost = CalculateSellCost(activeTower.name);
			Manager.Data.Gold += sellCost;
		}

		ResetTileState();
	}

	private int CalculateSellCost(string towerName)
	{
		int level = ExtractLevelFromName(towerName);
		return BaseSellCost + (level - 1) * SellCostPerLevel;
	}

	private int ExtractLevelFromName(string name)
	{
		string[] parts = name.Split('_');
		foreach (string part in parts)
		{
			if (part.StartsWith("Level") && int.TryParse(part.Replace("Level", ""), out int level))
			{
				return level;
			}
		}
		return 1;
	}

	private void ResetTileState()
	{
		currentTower.ReturnTower();
		currentTower = null;
		towerName = string.Empty;
		isTowerPresent = false;
		Manager.UI.IsSellTower = false;
	}

	public void SetCurrentTower(Tower tower, string name)
	{
		currentTower = tower;
		towerName = name;
		isTowerPresent = tower != null;
	}

	private void MergeTower()
	{
		foreach (TowerTile towerTile in Manager.Game.TowerTiles)
		{
			if (towerTile != this && towerTile.isTowerPresent && towerTile.TowerName == TowerName)
			{
				towerSpawner.MergeTowers(this, towerTile);
				break;
			}
		}
	}
}
