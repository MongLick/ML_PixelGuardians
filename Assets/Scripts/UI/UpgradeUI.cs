using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
	private enum ButtonAction { DevilDamage, DevilSpeed, HumanDamage, HumanSpeed}

	[Header("Components")]
	[SerializeField] Button devilDamageButton;
	[SerializeField] Button devilSpeedButton;
	[SerializeField] Button humanDamageButton;
	[SerializeField] Button humanSpeedButton;

	private void Awake()
	{
		Manager.UI.UpgradeUI = this;
		gameObject.SetActive(false);
		devilDamageButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.DevilDamage));
		devilSpeedButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.DevilSpeed));
		humanDamageButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.HumanDamage));
		humanSpeedButton.onClick.AddListener(() => HandleButtonClick(ButtonAction.HumanSpeed));
	}

	private void HandleButtonClick(ButtonAction action)
	{
		switch (action)
		{
			case ButtonAction.DevilDamage:
				if (Manager.Data.Gold >= Manager.Data.DevilDamagePrice)
				{
					Manager.Data.Gold -= Manager.Data.DevilDamagePrice;
					Manager.Data.DevilAttackDamage += Manager.Data.TowerDamage;
					Manager.Data.DevilDamagePrice += Manager.Data.PriceIncreaseAmount;
				}
				break;
			case ButtonAction.DevilSpeed:
				if (Manager.Data.Gold >= Manager.Data.DevilSpeedPrice)
				{
					Manager.Data.Gold -= Manager.Data.DevilSpeedPrice;
					Manager.Data.DevilAttackSpeed += Manager.Data.TowerSpeed;
					Manager.Data.DevilSpeedPrice += Manager.Data.PriceIncreaseAmount;
				}
				break;
			case ButtonAction.HumanDamage:
				if (Manager.Data.Gold >= Manager.Data.HumanDamagePrice)
				{
					Manager.Data.Gold -= Manager.Data.HumanDamagePrice;
					Manager.Data.HumanAttackDamage += Manager.Data.TowerDamage;
					Manager.Data.HumanDamagePrice += Manager.Data.PriceIncreaseAmount; 
				}
				break;
			case ButtonAction.HumanSpeed:
				if (Manager.Data.Gold >= Manager.Data.HumanSpeedPrice)
				{
					Manager.Data.Gold -= Manager.Data.HumanSpeedPrice;
					Manager.Data.HumanAttackSpeed += Manager.Data.TowerSpeed;
					Manager.Data.HumanSpeedPrice += Manager.Data.PriceIncreaseAmount; 
				}
				break;
		}
	}
}
