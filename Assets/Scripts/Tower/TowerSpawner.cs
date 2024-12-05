using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] GameObject[] levelOneTowers; 
	[SerializeField] GameObject[] levelTwoTowers; 
	[SerializeField] GameObject[] levelThreeTowers;

	[Header("Specs")]
	[SerializeField] int spawnGold;

	public void SpawnTower(Transform tileTransform, int towerLevel)
	{
		if (towerLevel == 1)
		{
			if (Manager.Data.Gold >= spawnGold)
			{
				Manager.Data.Gold -= spawnGold;
			}
			else
			{
				return;
			}
		}

		GameObject towerPrefab = null;

		switch (towerLevel)
		{
			case 1:
				towerPrefab = levelOneTowers[Random.Range(0, levelOneTowers.Length)];
				break;
			case 2:
				towerPrefab = levelTwoTowers[Random.Range(0, levelTwoTowers.Length)];
				break;
			case 3:
				towerPrefab = levelThreeTowers[Random.Range(0, levelThreeTowers.Length)];
				break;
		}

		if (towerPrefab != null)
		{
			PooledObject towerPoolObject = Manager.Pool.GetPool(Manager.Game.TowerPrefab, tileTransform.position, Quaternion.identity);

			Tower tower = towerPoolObject.GetComponent<Tower>();

			if (tower != null)
			{
				tower.AddOrActivateTower(towerPrefab, tileTransform); 
			}

			TowerTile towerTile = tileTransform.GetComponent<TowerTile>();
			if (towerTile != null)
			{
				towerTile.SetCurrentTower(tower, towerPrefab.name);
			}
		}
	}

	public void MergeTowers(TowerTile tile1, TowerTile tile2)
	{
		if (tile1.TowerName == tile2.TowerName)
		{
			int nextLevel = GetNextLevel(tile1.TowerName);

			if (nextLevel > 0)
			{
				tile1.CurrentTower.ReturnTower();
				tile2.CurrentTower.ReturnTower();

				tile1.SetCurrentTower(null, "");
				tile2.SetCurrentTower(null, "");

				GameObject newTower = null;
				PooledObject towerPoolObject = null;
				switch (nextLevel)
				{
					case 2:
						newTower = levelTwoTowers[Random.Range(0, levelTwoTowers.Length)];
						towerPoolObject = Manager.Pool.GetPool(Manager.Game.TowerPrefab, tile1.transform.position, Quaternion.identity);
						break;
					case 3:
						newTower = levelThreeTowers[Random.Range(0, levelThreeTowers.Length)];
						towerPoolObject = Manager.Pool.GetPool(Manager.Game.TowerPrefab, tile1.transform.position, Quaternion.identity);
						break;
				}

				Tower newTowerScript = towerPoolObject.GetComponent<Tower>();
				if (newTowerScript != null)
				{
					newTowerScript.AddOrActivateTower(newTower, tile1.transform);
				}

				tile1.SetCurrentTower(newTowerScript, newTower.name);
			}
		}
	}

	private int GetNextLevel(string towerName)
	{
		if (towerName.Contains("_Level1"))
			return 2; 
		if (towerName.Contains("_Level2"))
			return 3; 
		return 0;
	}
}
