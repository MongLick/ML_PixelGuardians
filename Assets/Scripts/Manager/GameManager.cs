using System.Collections;
using System.Collections.Generic;
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

	[Header("Specs")]
	[SerializeField] float spawnDelay;
	[SerializeField] int monsterCount;
	[SerializeField] int currentMonsterCount;
	[SerializeField] int waveNumber;
	public int WaveNumber { get { return waveNumber; } set { waveNumber = value; } }

	public void StartGame()
	{
		Manager.Pool.CreatePool(monsterPrefab, 15, 30);
		Manager.Pool.CreatePool(towerPrefab, 10, 25);
		StartWave();
	}

	public void StartWave()
	{
		ChangeMonsterSprites();
		StartCoroutine(SpawnMonster());
	}

	private void ChangeMonsterSprites()
	{
		monsterPrefab.Render.sprite = monsterSprites[waveNumber];
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
		Manager.UI.ButtonHandler.CurrentActionChange();
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
			PooledObject monster = Manager.Pool.GetPool(monsterPrefab, wayPoints[0].position, Quaternion.identity);
			yield return new WaitForSeconds(spawnDelay);
		}

		yield return new WaitForSeconds(3f);
		waveNumber++;
		StartWave();
	}
}
