using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieSoundManager : MonoBehaviour {
    public AudioClip enemyDie, characterDie;
    public AudioSource adisrc;
    // Use this for initialization
    void Start () {
        enemyDie = Resources.Load<AudioClip>("EnemyDie");
        characterDie = Resources.Load<AudioClip>("CharacterDie");
        adisrc = GetComponent<AudioSource>();
    }

    //Play Sound function
    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "enemyDie":
                adisrc.clip = enemyDie;
                adisrc.PlayOneShot(enemyDie, 1f);
                break;
            case "characterDie":
                adisrc.clip = characterDie;
                adisrc.PlayOneShot(characterDie, 1f);
                break;
        }
    }
}
