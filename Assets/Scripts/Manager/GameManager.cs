using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	[Header("Components")]
	[SerializeField] Transform[] wayPoints;
	public Transform[] WayPoints { get { return wayPoints; } set { wayPoints = value; } }

	[Header("Specs")]
	[SerializeField] float spawnDelay;
	[SerializeField] int monsterCount;
	[SerializeField] int currentMonsterCount;
	[SerializeField] int waveNumber;
	public int WaveNumber { get { return waveNumber; } set { waveNumber = value; } }

	[SerializeField] PooledObject monsterPrefabs;
	[SerializeField] List<Sprite> monsterSprites;

	public void StartGame()
	{
		Manager.Pool.CreatePool(monsterPrefabs, 15, 30);
		StartWave();
	}

	public void StartWave()
	{
		ChangeMonsterSprites();
		StartCoroutine(SpawnMonster());
	}

	private void ChangeMonsterSprites()
	{
		monsterPrefabs.Render.sprite = monsterSprites[waveNumber];
	}

	private IEnumerator SpawnMonster()
	{
		currentMonsterCount = monsterCount;
		while (currentMonsterCount > 0)
		{
			currentMonsterCount--;
			PooledObject monster = Manager.Pool.GetPool(monsterPrefabs, wayPoints[0].position, Quaternion.identity);
			yield return new WaitForSeconds(spawnDelay);
		}

		yield return new WaitForSeconds(3f);
		waveNumber++;
		StartWave();
	}
}
