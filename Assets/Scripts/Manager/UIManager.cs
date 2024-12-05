using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	[Header("Components")]
	[SerializeField] TowerUI towerUI;	
	public TowerUI TowerUI { get { return towerUI; } set { towerUI = value; } }
	[SerializeField] UpgradeUI upgradeUI;
	public UpgradeUI UpgradeUI { get {return upgradeUI; } set {upgradeUI = value; } }
	[SerializeField] VictoryUI victoryUI;
	public VictoryUI VictoryUI { get { return victoryUI; } set { victoryUI = value; } }

	[Header("Specs")]
	private bool isSellTower;
	public bool IsSellTower { get { return isSellTower; } set { isSellTower = value; } }
	private bool isSpawnTower;
	public bool IsSpawnTower { get { return isSpawnTower; } set { isSpawnTower = value; } }
	private bool isMergeTower;
	public bool IsMergeTower { get { return isMergeTower; } set { isMergeTower = value; } }
}
