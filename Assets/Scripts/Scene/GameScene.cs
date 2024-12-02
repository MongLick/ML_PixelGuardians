using UnityEngine;
using System.Collections;

public class GameScene : BaseScene
{
	[Header("Components")]
	[SerializeField] Transform[] wayPoints;

	private void OnEnable()
	{
		GameManagerSetUp();
	}

	private void GameManagerSetUp()
	{
		Manager.Game.WayPoints = wayPoints;
		Manager.Game.StartGame();
	}

	public override IEnumerator LoadingRoutine()
	{
		throw new System.NotImplementedException();
	}
}
