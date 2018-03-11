using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    // Character max health 
    public float maxHealth;
    // Character curent health 
    public float currentHealth;
    // Blood effect when character dies
    public GameObject bloodEffect;
    // Declare Sound 
    public characterSoundManager characterSound;
    public dieSoundManager dieSound;
    // Declare UI variables 
    public Slider playerHealthSlider;

    /// <summary>
    /// When game starts: Player have max health, health bar is full 
    /// and sound objects get sound manager files
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
        characterSound = GameObject.FindGameObjectWithTag("CharacterSound").GetComponent<characterSoundManager>();
        dieSound = GameObject.FindGameObjectWithTag("DieSound").GetComponent<dieSoundManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Player loses health when enemies ỏ traps cause damage
    /// Play losing health sound
    /// Dead when running out of health
    /// </summary>
    /// <param name="damage"></param>
    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        characterSound.Playsound("losingHealth");
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    // First attempt
    public static int playerScore = 1;

    /// <summary>
    /// Die function: play character die sound, have blood effect, deactivate character, 
    /// load gameover scene and increment attempt
    /// </summary>
    public void makeDead()
    {
        dieSound.Playsound("characterDie");
        Instantiate(bloodEffect, transform.position, transform.rotation);
        gameObject.SetActive(false);
        SceneManager.LoadScene("GameOver");
        playerScore++;
    }
}