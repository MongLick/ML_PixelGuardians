using UnityEngine;

public static class Manager
{
	public static GameManager Game { get { return GameManager.Instance; } }
	public static PoolManager Pool { get { return PoolManager.Instance; } }
	public static SceneManager Scene { get { return SceneManager.Instance; } }
	public static SoundManager Sound { get { return SoundManager.Instance; } }
	public static UIManager UI { get { return UIManager.Instance; }}
	public static DataManager Data { get { return DataManager.Instance;} }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Initialize()
	{
		GameManager.ReleaseInstance();
		PoolManager.ReleaseInstance();
		SceneManager.ReleaseInstance();
		SoundManager.ReleaseInstance();
		UIManager.ReleaseInstance();	
		DataManager.ReleaseInstance();

		GameManager.CreateInstance();
		PoolManager.CreateInstance();
		SceneManager.CreateInstance();
		SoundManager.CreateInstance();
		UIManager.CreateInstance();
		DataManager.CreateInstance();
	}
}
