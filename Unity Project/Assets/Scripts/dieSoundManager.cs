using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieSoundManager : MonoBehaviour
{
    // Audio clip declare
    public AudioClip enemyDie, characterDie;
    // Audio source declare
    public AudioSource adisrc;

    /// <summary>
    /// Load the audio source
    /// </summary>
    void Start()
    {
        enemyDie = Resources.Load<AudioClip>("EnemyDie");
        characterDie = Resources.Load<AudioClip>("CharacterDie");
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
