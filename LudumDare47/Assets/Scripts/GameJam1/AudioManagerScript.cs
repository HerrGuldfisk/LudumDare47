using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioClip sfxJump, sfxLanding, sfxAj,
        sfxRespawnDeath, sfxWin, sfxSpears, sfxCanon,
        sfxFalling, sfxExplosion;
    static AudioSource audioSrc;

	public static AudioManagerScript _instance;
	public static AudioManagerScript Instance { get { return _instance; } }

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}
	}
		// Start is called before the first frame update
	void Start()
    {
        sfxJump = Resources.Load<AudioClip>("sfxJump");
        sfxLanding = Resources.Load<AudioClip>("sfxLanding");
        sfxAj = Resources.Load<AudioClip>("sfxAj");
        //sfxJump = Resources.Load<AudioClip>("sfxJump");
        //sfxJump = Resources.Load<AudioClip>("sfxJump");
        //sfxJump = Resources.Load<AudioClip>("sfxJump");
        //sfxJump = Resources.Load<AudioClip>("sfxJump");
        //sfxJump = Resources.Load<AudioClip>("sfxJump");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch(clip){
            case "sfxJump":
                audioSrc.volume = 0.05f;
                audioSrc.loop = false;
                audioSrc.PlayOneShot(sfxJump);
                break;

            case "sfxLanding":
                audioSrc.volume = 0.01f;
                audioSrc.loop = false;
                audioSrc.PlayOneShot(sfxLanding);
                break;

            case "sfxAj":
                audioSrc.volume = 0.3f;
                audioSrc.loop = false;
                audioSrc.PlayOneShot(sfxAj);
                break;
        }
    }
}
