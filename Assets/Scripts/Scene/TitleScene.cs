using System.Collections;

public class TitleScene : BaseScene
{
	private void OnEnable()
	{
		Manager.Sound.PlayBGM(Manager.Sound.TitleClip);
	}

	public override IEnumerator LoadingRoutine()
	{
		yield return null;
	}
}
