using UnityEngine;

public class TowerController : MonoBehaviour
{
	private enum TowerType { Devil, Human }

	[Header("Components")]
	[SerializeField] Collider[] hitColliders;
	[SerializeField] TowerData towerData;
	public TowerData TowerData { get { return towerData; } }
	[SerializeField] Animator animator;
	[SerializeField] LayerMask monsterLayer;
	[SerializeField] TowerType type;

	[Header("Specs")]
	[SerializeField] string towerType;
	[SerializeField] float damage;
	[SerializeField] float attackRate;
	[SerializeField] float attackCoolTime;
	[SerializeField] int level;

	private void Awake()
	{
		towerType = type.ToString();
		UpdateTowerData();
		attackCoolTime = towerData.attackCoolTime;
	}

	private void OnEnable()
	{
		UpdateTowerData();
		if (type == TowerType.Devil)
		{
			Manager.Data.OnDevilDataChanged += UpdateTowerData;
		}
		else if (type == TowerType.Human)
		{
			Manager.Data.OnHumanDataChanged += UpdateTowerData;
		}
	}

	private void OnDisable()
	{
		if (type == TowerType.Devil)
		{
			Manager.Data.OnDevilDataChanged -= UpdateTowerData;
		}
		else if (type == TowerType.Human)
		{
			Manager.Data.OnHumanDataChanged -= UpdateTowerData;
		}
	}

	private void Update()
	{
		if (attackCoolTime >= 0)
		{
			attackCoolTime -= Time.deltaTime;
		}

		hitColliders = Physics.OverlapSphere(transform.position, towerData.range, monsterLayer);

		if (hitColliders.Length > 0)
		{
			if (attackCoolTime <= 0)
			{
				Attack();
			}
		}
	}

	private void Attack()
	{
		Transform targetMonster = hitColliders[0].transform;

		RotateTowardsTarget(targetMonster);

		animator.SetTrigger("Attack");

		int particleIndex = -1;

		if (type == TowerType.Devil)
		{
			particleIndex = level - 1;
		}
		else if (type == TowerType.Human)
		{
			particleIndex = level + 2;
		}

		Manager.Game.GetEffectFromPool(particleIndex, targetMonster.position, Quaternion.identity);

		Manager.Sound.PlayTowerAttackSound(towerType, level);

		IDamageable damageable = hitColliders[0].GetComponent<IDamageable>();
		if (damageable != null)
		{
			damageable.TakeDamage(damage);
		}

		attackCoolTime = attackRate;
	}

	private void RotateTowardsTarget(Transform targetTransform)
	{
		Vector3 direction = targetTransform.position - transform.position;

		if (direction.x > 0)
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
		else
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}

	private void UpdateTowerData()
	{
		switch (type)
		{
			case TowerType.Devil:
				damage = towerData.damage + Manager.Data.DevilAttackDamage;
				attackRate = Mathf.Max(0.1f, towerData.attackRate - Manager.Data.DevilAttackSpeed);
				break;

			case TowerType.Human:
				damage = towerData.damage + Manager.Data.HumanAttackDamage;
				attackRate = Mathf.Max(0.1f, towerData.attackRate - Manager.Data.HumanAttackSpeed);
				break;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, towerData.range);
	}
}
