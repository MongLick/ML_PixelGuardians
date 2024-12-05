using UnityEngine;
using UnityEngine.Events;

public class MonsterData : MonoBehaviour
{
	[Header("UnityAction")]
	private UnityAction<float> onHealthChanged;
	public UnityAction<float> OnHealthChanged { get { return onHealthChanged; } set { onHealthChanged = value; } }

	[Header("Specs")]
	[SerializeField] float maxHealth;
	public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
	[SerializeField] float currentHealth;
	public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; onHealthChanged?.Invoke(currentHealth); } }

	public void Initialize(float health)
	{
		MaxHealth = health;    
		CurrentHealth = health; 
	}
}
