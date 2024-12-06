using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Button gameStartButton;

	private void Awake()
	{
		gameStartButton.onClick.AddListener(GameStart);
	}

	private void GameStart()
	{
		Manager.Scene.LoadScene("GameScene");
	}
}
