using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonBase<SoundManager>
{
    private Dictionary<string, AudioClip> audioLibrary = new Dictionary<string, AudioClip>();

    public AudioSource aSourceSFX;
    public AudioSource aSourceBGM;

    protected override void Awake()
    {
        base.Awake();

        Init();
    }

    void Init()
    {
        AudioClip[] aClips = ResourcesLoader.Instance.LoadAudioLibrary();

        aSourceSFX = gameObject.AddComponent<AudioSource>();
        aSourceBGM = gameObject.AddComponent<AudioSource>();
        aSourceBGM.loop = true;

        for (int i = 0; i < aClips.Length; i++)
        {
            audioLibrary.Add(aClips[i].name, aClips[i]);
        }
        PlayBGM("SplashBGM");
    }

    public void PlaySound(string clipName)
    {
        if (audioLibrary.TryGetValue(clipName, out AudioClip clip))
            aSourceSFX.PlayOneShot(clip);
        else
        {
            Debug.Log("No Audio Clip Found! => " + clipName);
        }
    }
    public void PlayBGM(string clipName)
    {
        aSourceBGM.Stop();
        if (audioLibrary.TryGetValue(clipName, out AudioClip clip))
        {
            aSourceBGM.clip = clip;
            aSourceBGM.Play();
        }
        else
        {
            Debug.Log("No Audio Clip Found! => " + clipName);
        }
    }
    public AudioClip GetClip(string clipName)
    {
        if (audioLibrary.TryGetValue(clipName, out AudioClip clip))
        {
            return clip;
        }
        else
        {
            Debug.Log("No Audio Clip Found! => " + clipName);
            return null;
        }
    }
}