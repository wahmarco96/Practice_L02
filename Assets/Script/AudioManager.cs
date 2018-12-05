using UnityEngine;

public class AudioManager : MonoBehaviour {
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get { return instance; }
    }

    public AudioSource sfxManager;
    public AudioClip lose;
    public AudioClip hurt;
    public AudioClip buff;
    public AudioClip jumpSlash;
    public AudioClip ulti;
    public float ultiClipTiming;
    bool ultiIsPlaying;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (ultiIsPlaying)
        {
            ultiClipTiming += 0.1f * Time.deltaTime;
            sfxManager.volume -= 0.8f * Time.deltaTime;


            if (ultiClipTiming >= 0.4f)
            {
                sfxManager.volume = 1f;
                ultiIsPlaying = false;
                ultiClipTiming = 0f;
            }
        }

    }

    public void SfxLose()
    {
        sfxManager.clip = lose;
        sfxManager.Play();
    }

    public void SfxHurt()
    {
        sfxManager.clip = hurt;
        sfxManager.Play();
    }
    public void SfxBuff()
    {
        sfxManager.clip = buff;
        sfxManager.Play();
    }
    public void SfxJumpSlash()
    {
        sfxManager.clip = jumpSlash;
        sfxManager.Play();
    }
    public void SfxUlti()
    {
        sfxManager.clip = ulti;
        sfxManager.Play();
        ultiIsPlaying = true;
    }
}
