using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
	[SerializeField] SpriteRenderer render;
	public SpriteRenderer Render { get { return render; } set { render = value; } }
	[SerializeField] bool autoRelease;
	[SerializeField] float releaseTime;

	private ObjectPool pool;
	public ObjectPool Pool { get { return pool; } set { pool = value; } }

	private void OnEnable()
	{
		if (autoRelease)
		{
			StartCoroutine(ReleaseRoutine());
		}
	}

	IEnumerator ReleaseRoutine()
	{
		yield return new WaitForSeconds(releaseTime);
		Release();
	}

	public void Release()
	{
		if (pool != null)
		{
			pool.ReturnPool(this);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
