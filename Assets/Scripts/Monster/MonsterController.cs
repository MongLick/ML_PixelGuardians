using System.Threading;
using UnityEngine;

public class MonsterController : MonoBehaviour, IDamageable
{
	[Header("Components")]
	[SerializeField] Transform[] wayPoints;
	[SerializeField] MonsterData monsterData;
	[SerializeField] MonsterView monsterView;
	[SerializeField] PooledObject pooledObject;

	[Header("Specs")]
	[SerializeField] float moveSpeed;
	[SerializeField] float reachDistance;
	[SerializeField] int currentWaypointIndex;
	private bool isLastMonster;
	public bool IsLastMonster { get { return isLastMonster; } set { isLastMonster = value; } }
	private bool isDead;

	private void Start()
	{
		wayPoints = Manager.Game.WayPoints;
	}

	private void OnEnable()
	{
		isDead = false;
	}

	private void Update()
	{
		Transform targetWaypoint = wayPoints[currentWaypointIndex];
		Vector3 direction = targetWaypoint.position - transform.position;

		if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
		{
			if (direction.x > 0)
			{
				transform.rotation = Quaternion.Euler(0, 0, 0);
			}
			else
			{
				transform.rotation = Quaternion.Euler(0, 180, 0);
			}
		}
		else
		{
			if (direction.y > 0)
			{
				transform.rotation = Quaternion.Euler(0, 180, 0);
			}
			else
			{
				transform.rotation = Quaternion.Euler(0, 0, 0);
			}
		}

		transform.position += direction.normalized * moveSpeed * Time.deltaTime;

		if (Vector3.Distance(transform.position, targetWaypoint.position) < reachDistance)
		{
			currentWaypointIndex++;

			if (currentWaypointIndex >= wayPoints.Length)
			{
				currentWaypointIndex = 0;
			}
		}
	}

	public void TakeDamage(float damage)
	{
		if (isDead)
		{
			return;
		}

		monsterData.CurrentHealth -= damage;

		if (monsterData.CurrentHealth <= 0)
		{
			isDead = true;

			if (isLastMonster)
			{
				LastDie();
			}
			else
			{
				Die();
			}
		}
	}

	private void Die()
	{
		pooledObject.Pool.ReturnPool(pooledObject);
		currentWaypointIndex = 0;
		monsterData.CurrentHealth = monsterData.MaxHealth;
		Manager.Data.CurrentMonsterCount--;
	}

	private void LastDie()
	{
		pooledObject.Pool.ReturnPool(pooledObject);
		Time.timeScale = 0f;
		Manager.UI.VictoryUI.gameObject.SetActive(true);
	}

	public void Initialize(float maxHealth)
	{
		monsterData.Initialize(maxHealth);
		monsterView.Initialize(monsterData);
	}
}
