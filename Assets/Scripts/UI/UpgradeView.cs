using TMPro;
using UnityEngine;

public class UpgradeView : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] TMP_Text devilDamageText;
	[SerializeField] TMP_Text devilSpeedText;
	[SerializeField] TMP_Text humanDamageText;
	[SerializeField] TMP_Text humanSpeedText;

	private void OnEnable()
	{
		Manager.Data.OnDevilDamageChanged += UpdateDevilDamageText;
		Manager.Data.OnDevilSpeedChanged += UpdateDevilSpeedText;
		Manager.Data.OnHumanDamageChanged += UpdateHumanDamageText;
		Manager.Data.OnHumanSpeedChanged += UpdateHumanSpeedText;
	}

	private void OnDisable()
	{
		Manager.Data.OnDevilDamageChanged -= UpdateDevilDamageText;
		Manager.Data.OnDevilSpeedChanged -= UpdateDevilSpeedText;
		Manager.Data.OnHumanDamageChanged -= UpdateHumanDamageText;
		Manager.Data.OnHumanSpeedChanged -= UpdateHumanSpeedText;
	}

	private void UpdateDevilDamageText()
	{
		devilDamageText.text = Manager.Data.DevilDamagePrice.ToString();
	}

	private void UpdateDevilSpeedText()
	{
		devilSpeedText.text = Manager.Data.DevilSpeedPrice.ToString();
	}

	private void UpdateHumanDamageText()
	{
		humanDamageText.text = Manager.Data.HumanDamagePrice.ToString();
	}

	private void UpdateHumanSpeedText()
	{
		humanSpeedText.text = Manager.Data.HumanSpeedPrice.ToString();
	}
}
