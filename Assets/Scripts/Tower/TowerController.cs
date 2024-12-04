using UnityEngine;

public class TowerController : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Collider[] hitColliders;
	[SerializeField] Animator animator;
	[SerializeField] TowerData towerData;
	[SerializeField] LayerMask monsterLayer;

	[Header("Specs")]
	[SerializeField] float damage;
	[SerializeField] float attackRate;
	[SerializeField] float attackCoolTime;

	private void Awake()
	{
		damage = towerData.damage;
		attackRate = towerData.attackRate;
		attackCoolTime = towerData.attackCoolTime;
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
		animator.SetTrigger("Attack");
		IDamageable damageable = hitColliders[0].GetComponent<IDamageable>();
		if (damageable != null)
		{
			damageable.TakeDamage(damage);
		}
		attackCoolTime = attackRate;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, towerData.range);
	}
}
