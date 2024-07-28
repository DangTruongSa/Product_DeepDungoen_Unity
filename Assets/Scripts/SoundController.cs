using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static SoundController Instance { get; private set; }

    public AudioClip attack, holdattack, kill, playerdie, soundtrack;
    private AudioSource audioSource;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);

    }

    public void StopAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Stop();
    }

    public void StopSuondTrack()
    {
        StopAudioClip(soundtrack);
    }
    public void PlaySoundKill()
    {
        PlayAudioClip(kill);
    }

    public void PlaySoundattack()
    {
        PlayAudioClip(attack);
    }

    public void PlaySoundholdattack()
    {
        PlayAudioClip(holdattack);
    }

    public void Stopholdattack()
    {
        StopAudioClip(holdattack);
    }

    public void PlaySoundplayerdie()
    {
        PlayAudioClip(playerdie);
    }
    public void PlaySoundSoundTrack()
    {
        PlayAudioClip(soundtrack);
    }
}
