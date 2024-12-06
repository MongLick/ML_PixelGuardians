using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfoUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] Button missionButton;
	[SerializeField] Button settingButton;

	private void Awake()
	{
		Manager.UI.GameInfoUI = this;
	}
}
