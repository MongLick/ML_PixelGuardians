using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	[Header("Components")]
	[SerializeField] ButtonHandler buttonHandler;	
	public ButtonHandler ButtonHandler { get { return buttonHandler; } set { buttonHandler = value; } }

	[Header("Specs")]
	private bool isSellTower;
	public bool IsSellTower { get { return isSellTower; } set { isSellTower = value; } }
	private bool isSpawnTower;
	public bool IsSpawnTower { get { return isSpawnTower; } set { isSpawnTower = value; } }
	private bool isMergeTower;
	public bool IsMergeTower { get { return isMergeTower; } set { isMergeTower = value; } }
}
