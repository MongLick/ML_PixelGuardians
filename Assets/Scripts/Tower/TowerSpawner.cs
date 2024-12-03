using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] GameObject[] levelOneTowers; 
	[SerializeField] GameObject[] levelTwoTowers; 
	[SerializeField] GameObject[] levelThreeTowers;

	public void SpawnTower(Transform tileTransform, int towerLevel)
	{
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
			GameObject newTower = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
			TowerTile towerTile = tileTransform.GetComponent<TowerTile>();
			if (towerTile != null)
			{
				towerTile.SetCurrentTower(newTower);
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
				Destroy(tile1.CurrentTower);
				Destroy(tile2.CurrentTower);

				tile1.SetCurrentTower(null);
				tile2.SetCurrentTower(null);

				GameObject newTower = null;
				switch (nextLevel)
				{
					case 2:
						newTower = Instantiate(levelTwoTowers[Random.Range(0, levelTwoTowers.Length)], tile1.transform.position, Quaternion.identity);
						Debug.Log(1);
						break;
					case 3:
						newTower = Instantiate(levelThreeTowers[Random.Range(0, levelThreeTowers.Length)], tile1.transform.position, Quaternion.identity);
						break;
				}
				tile1.SetCurrentTower(newTower);
			}
		}
	}

	private int GetNextLevel(string towerName)
	{
		if (towerName.Contains("_One"))
			return 2; 
		if (towerName.Contains("_Two"))
			return 3; 
		return 0;
	}
}
