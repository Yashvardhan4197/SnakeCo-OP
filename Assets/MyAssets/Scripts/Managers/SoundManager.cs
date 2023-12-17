using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    [SerializeField] AudioSource SoundSFX;
    [SerializeField] AudioSource BgSound;
    [SerializeField] SoundTypes[] soundTypes;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        Playbg(Sound.bgMusic);
    }

    [Serializable] class SoundTypes
    {
        public Sound soundtype;
        public AudioClip audioclip;
    };

    public void Playbg(Sound sound)
    {
        AudioClip clip = GetAudioClip(sound);
        BgSound.clip = clip;
        BgSound.Play();
    }
    public void PlaySfx(Sound sound)
    {
        AudioClip audioclip = GetAudioClip(sound);
        if(audioclip != null) 
        {
            SoundSFX.PlayOneShot(audioclip);
        }
    }

    private AudioClip GetAudioClip(Sound sound)
    {
        SoundTypes item=Array.Find(soundTypes,i=>i.soundtype == sound );
        if(item!=null)
        {
            return item.audioclip;
        }
        return null;
    }

    public enum Sound {buttonClick,SnakeEat,Snakedeath,bgMusic, null1 };
}
