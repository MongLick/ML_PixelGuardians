using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	[Header("Components")]
	[SerializeField] TowerUI towerUI;
	public TowerUI TowerUI { get { return towerUI; } set { towerUI = value; } }
	[SerializeField] UpgradeUI upgradeUI;
	public UpgradeUI UpgradeUI { get { return upgradeUI; } set { upgradeUI = value; } }
	[SerializeField] GameInfoUI gameInfoUI;
	public GameInfoUI GameInfoUI { get { return gameInfoUI; } set { gameInfoUI = value; } }
	[SerializeField] VictoryUI victoryUI;
	public VictoryUI VictoryUI { get { return victoryUI; } set { victoryUI = value; } }
	[SerializeField] DefeatUI defeatUI;
	public DefeatUI DefeatUI { get { return defeatUI; } set { defeatUI = value; } }
	[SerializeField] TowerPrefabUI towerPrefabUI;
	public TowerPrefabUI TowerPrefabUI { get {return towerPrefabUI; } set {towerPrefabUI = value; } }
	[SerializeField] PauseUI pauseUI;
	public PauseUI PauseUI { get { return pauseUI; } set { pauseUI = value; } }
	[SerializeField] SoundUI soundUI;
	public SoundUI SoundUI { get { return soundUI; } set { soundUI = value; } }

	[Header("Specs")]
	private bool isSellTower;
	public bool IsSellTower { get { return isSellTower; } set { isSellTower = value; } }
	private bool isSpawnTower;
	public bool IsSpawnTower { get { return isSpawnTower; } set { isSpawnTower = value; } }
	private bool isMergeTower;
	public bool IsMergeTower { get { return isMergeTower; } set { isMergeTower = value; } }
}
