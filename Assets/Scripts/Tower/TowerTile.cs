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
			ray = mainCamera.ScreenPointToRay(eventData.position);
			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				towerSpawner.SpawnTower(hit.transform, 1);
				Manager.UI.IsSpawnTower = false;
			}
		}
		else if (Manager.UI.IsMergeTower && isTowerPresent)
		{
			MergeTower();
		}

		Manager.Game.DisableAllTileOverlays();
	}

	public void ChangeColor(Color color)
	{
		if (Manager.UI.IsSellTower && isTowerPresent)
		{
			overlayImage.gameObject.SetActive(true);
			overlayImage.color = color;
		}
		else if (Manager.UI.IsSpawnTower && !isTowerPresent)
		{
			overlayImage.gameObject.SetActive(true);
			overlayImage.color = color;
		}
		else if (Manager.UI.IsMergeTower && isTowerPresent)
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
		if (currentTower != null)
		{
			currentTower.ReturnTower();
			currentTower = null;
			towerName = "";
			isTowerPresent = false;
			Manager.UI.IsSellTower = false;
		}
	}

	public void SetCurrentTower(Tower tower, string name)
	{
		if(tower != null)
		{
			currentTower = tower;
			towerName = name;
			isTowerPresent = true;
		}
		else
		{
			currentTower = null;
			towerName = "";
			isTowerPresent = false;
		}
	}

	private void MergeTower()
	{
		foreach (TowerTile towerTile in Manager.Game.TowerTiles)
		{
			if (towerTile != this && towerTile.isTowerPresent && towerTile.TowerName == this.TowerName)
			{
				towerSpawner.MergeTowers(this, towerTile);
				break; 
			}
		}
	}
}
