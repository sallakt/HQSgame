﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {
    public float maxHealth;
    public float currentHealth;
    public GameObject bloodEffect;
    //Declare Sound 
    public characterSoundManager characterSound;
    public dieSoundManager dieSound;

    //Declare UI variables 
    public Slider playerHealthSlider;
    
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
        characterSound = GameObject.FindGameObjectWithTag("CharacterSound").GetComponent<characterSoundManager>();
        dieSound = GameObject.FindGameObjectWithTag("DieSound").GetComponent<dieSoundManager>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        characterSound.Playsound("losingHealth");
        if (currentHealth <=0)
        {
            makeDead();
        }
    }

	public static int playerScore = 1;
    public void makeDead()
    {
        dieSound.Playsound("characterDie");
        Instantiate(bloodEffect, transform.position, transform.rotation);
        gameObject.SetActive(false);
		SceneManager.LoadScene ("GameOver");
		playerScore++;
    }
}