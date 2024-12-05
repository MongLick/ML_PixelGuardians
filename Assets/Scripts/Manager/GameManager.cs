using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	[Header("Components")]
	[SerializeField] Transform[] wayPoints;
	public Transform[] WayPoints { get { return wayPoints; } set { wayPoints = value; } }
	[SerializeField] TowerTile[] towerTile;
	public TowerTile[] TowerTiles { get { return towerTile; } set { towerTile = value; } }
	[SerializeField] PooledObject monsterPrefab;
	[SerializeField] PooledObject towerPrefab;
	public PooledObject TowerPrefab { get { return towerPrefab; } set { towerPrefab = value; } }
	[SerializeField] List<Sprite> monsterSprites;
	[SerializeField] int[] monsterHealth;

	[Header("Specs")]
	private const int stagegold = 300;
	[SerializeField] float spawnDelay;
	[SerializeField] int monsterCount;
	[SerializeField] int currentMonsterCount;

	public void StartGame()
	{
		Manager.Pool.CreatePool(monsterPrefab, 15, 30);
		Manager.Pool.CreatePool(towerPrefab, 10, 25);
		StartWave();
	}

	public void StartWave()
	{
		ChangeMonster();
		StartCoroutine(SpawnMonster());
	}

	private void ChangeMonster()
	{
		monsterPrefab.Render.sprite = monsterSprites[Manager.Data.StageNumber -1];
	}

	public void ChangeTileColors(Color color)
	{
		foreach (TowerTile tile in towerTile)
		{
			tile.ChangeColor(color);
		}
	}

	public void DisableAllTileOverlays()
	{
		Manager.UI.TowerUI.CurrentActionChange();
		foreach (TowerTile tile in towerTile)
		{
			tile.DisableImage();
		}
	}

	private IEnumerator SpawnMonster()
	{
        currentMonsterCount = monsterCount;
		while (currentMonsterCount > 0)
		{
			currentMonsterCount--;
			Manager.Data.CurrentMonsterCount++;
			PooledObject monsterObject = Manager.Pool.GetPool(monsterPrefab, wayPoints[0].position, Quaternion.identity);

			MonsterController monster = monsterObject.GetComponent<MonsterController>();
			if (monster != null)
			{
				monster.Initialize(monsterHealth[Manager.Data.StageNumber -1]);
			}

			yield return new WaitForSeconds(spawnDelay);
		}

		yield return new WaitForSeconds(3f);
		Manager.Data.StageNumber++;
		Manager.Data.Gold += stagegold;
		StartWave();
	}
}
