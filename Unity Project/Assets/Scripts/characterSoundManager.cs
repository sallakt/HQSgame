using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSoundManager : MonoBehaviour
{

    public AudioClip jump, losingHealth, shoot;
    public AudioSource adisrc;

    // Use this for initialization
    void Start()
    {
        jump = Resources.Load<AudioClip>("Jump");
        losingHealth = Resources.Load<AudioClip>("Losinghealth");
        shoot = Resources.Load<AudioClip>("Shoot");
        adisrc = GetComponent<AudioSource>();
    }

    //Play Sound function
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
