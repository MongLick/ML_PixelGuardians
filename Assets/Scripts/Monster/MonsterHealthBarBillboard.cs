using UnityEngine;

public class MonsterHealthBarBillboard : MonoBehaviour
{
	private void LateUpdate()
	{
		transform.forward = Camera.main.transform.forward;
	}
}
