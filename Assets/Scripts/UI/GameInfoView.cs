using System.Collections;
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
		Manager.Game.OnLastMonsterSpawned += UpdateLastMonsterTimeText;
	}

	private void OnDisable()
	{
		Manager.Data.OnGoldChanged -= UpdateGoldText;
		Manager.Data.OnStageNumberChanged -= UpdateStageText;
		Manager.Data.OnMonsterCountChanged -= UpdateMonsterCountText;
		Manager.Game.OnLastMonsterSpawned -= UpdateLastMonsterTimeText;
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

	private void UpdateLastMonsterTimeText()
	{
		Manager.Data.OnMonsterCountChanged -= UpdateMonsterCountText;
		StartCoroutine(StartCountdown(60));
	}

	private IEnumerator StartCountdown(float time)
	{
		float timeRemaining = time;

		while (timeRemaining > 0)
		{
			timeRemaining -= Time.deltaTime;

			int minutes = Mathf.FloorToInt(timeRemaining / 60);
			int seconds = Mathf.FloorToInt(timeRemaining % 60);

			monsterCountText.text = $"Time\n<color=red>{minutes:00}:{seconds:00}</color>";

			yield return null;
		}

		monsterCountText.text = "Time\n<color=red>00:00</color>";
		Manager.UI.DefeatUI.gameObject.SetActive(true);
		Manager.Game.GameOver();
		Time.timeScale = 0f;
	}
}
