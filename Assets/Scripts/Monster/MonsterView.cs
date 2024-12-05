using UnityEngine;
using UnityEngine.UI;

public class MonsterView : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] MonsterData monsterData;
	[SerializeField] Slider healthBar;

	private void OnEnable()
	{
		monsterData.OnHealthChanged += UpdateView;
	}

	private void OnDisable()
	{
		monsterData.OnHealthChanged -= UpdateView;
	}

	public void Initialize(MonsterData data)
	{
		monsterData = data;
		healthBar.maxValue = monsterData.MaxHealth;
		healthBar.value = monsterData.CurrentHealth;
	}

	private void UpdateView(float value)
	{
		healthBar.value = value;
	}
}
