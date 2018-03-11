using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSoundManager : MonoBehaviour
{
    // Audio clip declare
    public AudioClip jump, losingHealth, shoot;
    // Audio source declare
    public AudioSource adisrc;

    /// <summary>
    /// Load the audio source
    /// </summary>
    void Start()
    {
        jump = Resources.Load<AudioClip>("Jump");
        losingHealth = Resources.Load<AudioClip>("Losinghealth");
        shoot = Resources.Load<AudioClip>("Shoot");
        adisrc = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Play Sound function
    /// </summary>
    /// <param name="clip"></param>
    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "jump":
                adisrc.clip = jump;
                adisrc.PlayOneShot(jump, 1f);
                break;
            case "losingHealth":
                adisrc.clip = losingHealth;
                adisrc.PlayOneShot(losingHealth, 1f);
                break;
            case "shoot":
                adisrc.clip = shoot;
                adisrc.PlayOneShot(shoot, 1f);
                break;
        }
    }
}
