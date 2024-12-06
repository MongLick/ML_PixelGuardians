using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/Game")]
public class GameData : ScriptableObject
{
	public float devilAttackDamage;
	public float devilAttackSpeed;
	public float humanAttackDamage;
	public float humanAttackSpeed;
	public float towerDamage;
	public float towerSpeed;
	public int gold;
	public int stageNumber;
	public int currentMonsterCount;
	public int maxMonsterCount;
	public int devilDamagePrice;
	public int devilSpeedPrice;
	public int humanDamagePrice;
	public int humanSpeedPrice;
	public int priceIncreaseAmount;
}
