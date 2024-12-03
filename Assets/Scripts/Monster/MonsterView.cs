using UnityEngine;
using UnityEngine.UI;

public class MonsterView : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] MonsterData monsterData;
	[SerializeField] Slider healthBar;

	private void OnEnable()
	{
		InitializeHealthBar();
		monsterData.OnHealthCanged += UpdateView;
	}

	private void OnDisable()
	{
		monsterData.OnHealthCanged -= UpdateView;
	}

	private void InitializeHealthBar()
	{
		healthBar.maxValue = monsterData.MaxHealth;
		healthBar.value = monsterData.MaxHealth;
	}

	private void UpdateView(float value)
	{
		healthBar.value = value;
	}
}
