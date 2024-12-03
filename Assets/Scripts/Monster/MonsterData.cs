using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterData : MonoBehaviour
{
	[Header("UnityAction")]
	private UnityAction<float> onHealthCanged;
	public UnityAction<float> OnHealthCanged { get { return onHealthCanged; } set { onHealthCanged = value; } }

	[Header("Specs")]
	[SerializeField] float maxHealth;
	public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    [SerializeField] float currentHealth;
	public float CurrentHealth { get {return currentHealth; } set { currentHealth = value; onHealthCanged?.Invoke(value); } }

	private void Awake()
	{
		currentHealth = maxHealth;
	}
}
