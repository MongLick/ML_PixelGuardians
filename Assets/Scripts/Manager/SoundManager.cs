using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
	[Header("AudioSource")]
	[SerializeField] AudioSource bgmSource;
	public float BGMVolme { get { return bgmSource.volume; } set { bgmSource.volume = value; } }
	[SerializeField] AudioSource sfxSource;
	public float SFXVolme { get { return sfxSource.volume; } set { sfxSource.volume = value; } }

	[Header("SoundClips")]
	[Header("BGM")]
	[SerializeField] AudioClip titleClip;
	public AudioClip TitleClip { get { return titleClip; } set { titleClip = value; } }
	[SerializeField] AudioClip gameClip;
	public AudioClip GameClip { get { return gameClip; } set { gameClip = value; } }

	[Header("UI")]
	[SerializeField] AudioClip uiButtonClip;
	public AudioClip UIButtonClip { get { return uiButtonClip; } set { uiButtonClip = value; } }

	[Header("Tower")]
	[SerializeField] AudioClip devil01;
	public AudioClip Devil01 { get { return devil01; } set { devil01 = value; } }
	[SerializeField] AudioClip devil02;
	public AudioClip Devil02 { get { return devil02; } set { devil02 = value; } }
	[SerializeField] AudioClip devil03;
	public AudioClip Devil03 { get { return devil03; } set { devil03 = value; } }
	[SerializeField] AudioClip human01;
	public AudioClip Human01 { get { return human01; } set { human01 = value; } }
	[SerializeField] AudioClip human02;
	public AudioClip Human02 { get { return human02; } set { human02 = value; } }
	[SerializeField] AudioClip human03;
	public AudioClip Human03 { get { return human03; } set { human03 = value; } }

	public void PlayBGM(AudioClip clip)
	{
		if (bgmSource.isPlaying)
		{
			bgmSource.Stop();
		}
		bgmSource.clip = clip;
		bgmSource.Play();
	}

	public void StopBGM()
	{
		if (bgmSource.isPlaying == false)
			return;

		bgmSource.Stop();
	}

	public void PlaySFX(AudioClip clip)
	{
		sfxSource.PlayOneShot(clip);
	}

	public void StopSFX()
	{
		if (sfxSource.isPlaying == false)
			return;

		sfxSource.Stop();
	}

	public void UIPlaySFX()
	{
		sfxSource.PlayOneShot(uiButtonClip);
	}

	public void PlayTowerAttackSound(string towerType, int level)
	{
		AudioClip clip = null;

		switch (towerType)
		{
			case "Devil":
				if (level == 1) clip = devil01;
				else if (level == 2) clip = devil02;
				else if (level == 3) clip = devil03;
				break;

			case "Human":
				if (level == 1) clip = human01;
				else if (level == 2) clip = human02;
				else if (level == 3) clip = human03;
				break;
		}

		if (clip != null)
		{
			PlaySFX(clip);
		}
	}
}
