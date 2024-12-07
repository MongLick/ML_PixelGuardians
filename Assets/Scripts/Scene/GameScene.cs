using UnityEngine;
using System.Collections;

public class GameScene : BaseScene
{
	[Header("Components")]
	[SerializeField] Transform[] wayPoints;
	[SerializeField] TowerTile[] towerTiles;

	private void OnEnable()
	{
		GameManagerSetUp();
		Manager.Sound.PlayBGM(Manager.Sound.GameClip);
	}

	private void GameManagerSetUp()
	{
		Manager.Game.WayPoints = wayPoints;
		Manager.Game.TowerTiles = towerTiles;
		Manager.Data.StartGame();
		Manager.Game.StartGame();
	}

	public override IEnumerator LoadingRoutine()
	{
		yield return null;
	}
}
