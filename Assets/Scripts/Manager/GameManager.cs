using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
	[Header("UnityAction")]
	private UnityAction onLastMonsterSpawned;
	public UnityAction OnLastMonsterSpawned { get { return onLastMonsterSpawned; } set { onLastMonsterSpawned = value; } }

	[Header("Components")]
	[SerializeField] List<Sprite> monsterSprites;
	[SerializeField] Transform[] wayPoints;
	public Transform[] WayPoints { get { return wayPoints; } set { wayPoints = value; } }
	[SerializeField] TowerTile[] towerTile;
	public TowerTile[] TowerTiles { get { return towerTile; } set { towerTile = value; } }
	[SerializeField] PooledObject[] particlePrefabs;
	public PooledObject[] ParticlePrefabs { get {return particlePrefabs; } set { particlePrefabs = value; } }
	[SerializeField] PooledObject monsterPrefab;
	[SerializeField] PooledObject towerPrefab;
	public PooledObject TowerPrefab { get { return towerPrefab; } set { towerPrefab = value; } }

	[Header("Specs")]
	private const int lastStageNumber = 10;
	private const int stageGold = 350;
	[SerializeField] float spawnDelay;
	[SerializeField] int[] monsterHealth;
	[SerializeField] int monsterCount;
	[SerializeField] int currentMonsterCount;

	[Header("Coroutine")]
	private Coroutine spawnMonsterCoroutine;

	public void StartGame()
	{
		Manager.Pool.CreatePool(monsterPrefab, 30, 30);
		Manager.Pool.CreatePool(towerPrefab, 10, 25);
		foreach (PooledObject particlePrefab in particlePrefabs)
		{
			Manager.Pool.CreatePool(particlePrefab, 2, 5);
		}
		StartWave();
	}

	public void StartWave()
	{
		ChangeMonster();

		if (Manager.Data.StageNumber == lastStageNumber)
		{
			spawnMonsterCoroutine = StartCoroutine(LastSpawnMonster());
		}
		else
		{
			spawnMonsterCoroutine = StartCoroutine(SpawnMonster());
		}
	}

	private void ChangeMonster()
	{
		monsterPrefab.Render.sprite = monsterSprites[Manager.Data.StageNumber - 1];
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

	public void GameOver()
	{
		StopCoroutine(spawnMonsterCoroutine);
	}

	public GameObject GetEffectFromPool(int index, Vector3 position, Quaternion rotation)
	{
		PooledObject effectPrefab = particlePrefabs[index];
		GameObject effectObject = Manager.Pool.GetPool(effectPrefab, position, rotation).gameObject;
		return effectObject;
	}

	private IEnumerator SpawnMonster()
	{
		yield return new WaitForSeconds(3f);
		currentMonsterCount = monsterCount;
		while (currentMonsterCount > 0)
		{
			currentMonsterCount--;
			Manager.Data.CurrentMonsterCount++;
			PooledObject monsterObject = Manager.Pool.GetPool(monsterPrefab, wayPoints[0].position, Quaternion.identity);

			MonsterController monster = monsterObject.GetComponent<MonsterController>();
			if (monster != null)
			{
				monster.Initialize(monsterHealth[Manager.Data.StageNumber - 1]);
			}
			if (Manager.Data.CurrentMonsterCount >= Manager.Data.MaxMonsterCount)
			{
				GameOver();
				Manager.UI.DefeatUI.gameObject.SetActive(true);
				Time.timeScale = 0f;
			}
			yield return new WaitForSeconds(spawnDelay);
		}

		Manager.Data.StageNumber++;
		Manager.Data.Gold += stageGold;
		StartWave();
	}

	private IEnumerator LastSpawnMonster()
	{
		PooledObject monsterObject = Manager.Pool.GetPool(monsterPrefab, wayPoints[0].position, Quaternion.identity);
		MonsterController monster = monsterObject.GetComponent<MonsterController>();
		if (monster != null)
		{
			monster.Initialize(monsterHealth[Manager.Data.StageNumber - 1]);
			monster.transform.localScale *= 1.5f;
			monster.IsLastMonster = true;
			onLastMonsterSpawned.Invoke();
		}
		yield return null;
	}
}
