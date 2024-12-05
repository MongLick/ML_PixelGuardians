using UnityEngine;

[CreateAssetMenu (fileName = "TowerData", menuName = "Data/Tower")]
public class TowerData : ScriptableObject
{
	public string towerName;
	public float damage;
	public float range;
	public float attackRate;
	public float attackCoolTime;
}
