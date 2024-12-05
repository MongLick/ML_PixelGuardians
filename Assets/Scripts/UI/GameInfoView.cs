using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameInfoView : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] TMP_Text goldText;
	[SerializeField] TMP_Text stageText;
	[SerializeField] TMP_Text monsterCountText;

	private void OnEnable()
	{
		Manager.Data.OnGoldChanged += UpdateGoldText;
		Manager.Data.OnStageNumberChanged += UpdateStageText;
		Manager.Data.OnMonsterCountChanged += UpdateMonsterCountText;
	}

	private void OnDisable()
	{
		Manager.Data.OnGoldChanged -= UpdateGoldText;
		Manager.Data.OnStageNumberChanged -= UpdateStageText;
		Manager.Data.OnMonsterCountChanged -= UpdateMonsterCountText;
	}

	private void UpdateGoldText()
	{
		goldText.text = $"Gold : {Manager.Data.Gold}";
	}

	private void UpdateStageText()
	{
		stageText.text = $"Stage : {Manager.Data.StageNumber}";
	}

	private void UpdateMonsterCountText()
	{
		monsterCountText.text = $"{Manager.Data.CurrentMonsterCount} / {Manager.Data.MaxMonsterCount}";
	}
}
