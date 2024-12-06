using UnityEngine;
using UnityEngine.Events;

public class DataManager : Singleton<DataManager>
{
	[Header("UnityAction")]
	private UnityAction onDevilDataChanged;
	public UnityAction OnDevilDataChanged { get { return onDevilDataChanged; } set { onDevilDataChanged = value; } }
	private UnityAction onHumanDataChanged;
	public UnityAction OnHumanDataChanged { get { return onHumanDataChanged; } set { onHumanDataChanged = value; } }
	private UnityAction onDevilDamageChanged;
	public UnityAction OnDevilDamageChanged { get { return onDevilDamageChanged; } set { onDevilDamageChanged = value; } }
	private UnityAction onDevilSpeedChanged;
	public UnityAction OnDevilSpeedChanged { get { return onDevilSpeedChanged; } set { onDevilSpeedChanged = value; } }
	private UnityAction onHumanDamageChanged;
	public UnityAction OnHumanDamageChanged { get { return onHumanDamageChanged; } set { onHumanDamageChanged = value; } }
	private UnityAction onHumanSpeedChanged;
	public UnityAction OnHumanSpeedChanged { get { return onHumanSpeedChanged; } set { onHumanSpeedChanged = value; } }
	private UnityAction onGoldChanged;
	public UnityAction OnGoldChanged { get { return onGoldChanged; } set { onGoldChanged = value; } }
	private UnityAction onStageNumberChanged;
	public UnityAction OnStageNumberChanged { get { return onStageNumberChanged; } set { onStageNumberChanged = value; } }
	private UnityAction onMonsterCountChanged;
	public UnityAction OnMonsterCountChanged { get { return onMonsterCountChanged; } set { onMonsterCountChanged = value; } }

	[Header("Components")]
	[SerializeField] GameData gameData;

	[Header("Specs")]
	[SerializeField] float devilAttackDamage;
	public float DevilAttackDamage { get { return devilAttackDamage; } set { devilAttackDamage = value; onDevilDataChanged?.Invoke(); } }
	[SerializeField] float devilAttackSpeed;
	public float DevilAttackSpeed { get { return devilAttackSpeed; } set { devilAttackSpeed = value; onDevilDataChanged?.Invoke(); } }
	[SerializeField] float humanAttackDamage;
	public float HumanAttackDamage { get { return humanAttackDamage; } set { humanAttackDamage = value; onHumanDataChanged?.Invoke(); } }
	[SerializeField] float humanAttackSpeed;
	public float HumanAttackSpeed { get { return humanAttackSpeed; } set { humanAttackSpeed = value; onHumanDataChanged?.Invoke(); } }
	[SerializeField] float towerDamage;
	public float TowerDamage { get { return towerDamage; } set { towerDamage = value; } }
	[SerializeField] float towerSpeed;
	public float TowerSpeed { get { return towerSpeed; } set { towerSpeed = value; } }
	[SerializeField] int gold;
	public int Gold { get { return gold; } set { gold = value; onGoldChanged?.Invoke(); } }
	[SerializeField] int stageNumber;
	public int StageNumber { get { return stageNumber; } set { stageNumber = value; onStageNumberChanged?.Invoke(); } }
	[SerializeField] int currentMonsterCount;
	public int CurrentMonsterCount { get { return currentMonsterCount; } set { currentMonsterCount = value; onMonsterCountChanged?.Invoke(); } }
	[SerializeField] int maxMonsterCount;
	public int MaxMonsterCount { get { return maxMonsterCount; } set { maxMonsterCount = value; } }
	[SerializeField] int devilDamagePrice;
	public int DevilDamagePrice { get { return devilDamagePrice; } set { devilDamagePrice = value; onDevilDamageChanged?.Invoke(); } }
	[SerializeField] int devilSpeedPrice;
	public int DevilSpeedPrice { get { return devilSpeedPrice; } set { devilSpeedPrice = value; onDevilSpeedChanged?.Invoke(); } }
	[SerializeField] int humanDamagePrice;
	public int HumanDamagePrice { get { return humanDamagePrice; } set { humanDamagePrice = value; onHumanDamageChanged?.Invoke(); } }
	[SerializeField] int humanSpeedPrice;
	public int HumanSpeedPrice { get { return humanSpeedPrice; } set { humanSpeedPrice = value; onHumanSpeedChanged?.Invoke(); } }
	[SerializeField] int priceIncreaseAmount;
	public int PriceIncreaseAmount { get { return priceIncreaseAmount; } set { priceIncreaseAmount = value; } }

	public void StartGame()
	{
		devilAttackDamage = gameData.devilAttackDamage;
		devilAttackSpeed = gameData.devilAttackSpeed;
		humanAttackDamage = gameData.humanAttackDamage;
		humanAttackSpeed = gameData.humanAttackSpeed;
		towerDamage = gameData.towerDamage;
		towerSpeed = gameData.towerSpeed;
		gold = gameData.gold;
		stageNumber = gameData.stageNumber;
		currentMonsterCount = gameData.currentMonsterCount;
		maxMonsterCount = gameData.maxMonsterCount;
		devilDamagePrice = gameData.devilDamagePrice;
		devilSpeedPrice = gameData.devilSpeedPrice;
		humanDamagePrice = gameData.humanDamagePrice;
		humanSpeedPrice = gameData.humanSpeedPrice;
		priceIncreaseAmount = gameData.priceIncreaseAmount;
	}
}
