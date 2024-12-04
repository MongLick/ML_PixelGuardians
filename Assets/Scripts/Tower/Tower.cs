using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] PooledObject pooledObject;
    [SerializeField] List<GameObject> towerPrefabs = new List<GameObject>();

    public void ReturnTower()
    {
		foreach (GameObject tower in towerPrefabs)
		{
			tower.SetActive(false);
		}

		pooledObject.Pool.ReturnPool(pooledObject);
	}

	public void AddOrActivateTower(GameObject towerPrefab, Transform spawnPoint)
	{
		string towerNameWithoutClone = towerPrefab.name.Replace("(Clone)", "");

		foreach (GameObject existingTower in towerPrefabs)
		{
			string existingTowerName = existingTower.name.Replace("(Clone)", "");

			if (existingTowerName == towerNameWithoutClone)
			{
				existingTower.SetActive(true);
				return;
			}
		}

		GameObject newTower = Instantiate(towerPrefab, spawnPoint.position, Quaternion.identity);
		newTower.transform.SetParent(transform);
		towerPrefabs.Add(newTower);
	}
}
