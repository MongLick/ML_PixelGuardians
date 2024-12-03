using UnityEngine;

public class MonsterController : MonoBehaviour, IDamageable
{
	[Header("Components")]
	[SerializeField] Transform[] wayPoints;
	[SerializeField] MonsterData monsterData;

	[Header("Specs")]
	[SerializeField] float moveSpeed;
	[SerializeField] float reachDistance;
	[SerializeField] int currentWaypointIndex;

	private void Start()
	{
		wayPoints = Manager.Game.WayPoints;
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

	public void TakeDamage(float damege)
	{
		monsterData.CurrentHealth -= damege;
	}
}
