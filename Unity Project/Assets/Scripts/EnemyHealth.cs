using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Enemy max health, current health 
    public float maxHealth, currentHealth;
    // Enemy die effect
    public GameObject enemyHealthEF;
    // Enemyhealth UI
    public Slider enemyHealthSlider;
    // Declare die sound 
    public dieSoundManager dieSound;


    /// <summary>
    /// Set up initial values, sound object get sound manager file
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
        dieSound = GameObject.FindGameObjectWithTag("DieSound").GetComponent<dieSoundManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Activate enemy health slider. Put damage to enemy. 
    /// Call makeDead function and play sound if enemy dies
    /// </summary>
    /// <param name="damage"></param>
    public void addDamage(float damage)
    {
        enemyHealthSlider.gameObject.SetActive(true);
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            makeDead();
            dieSound.Playsound("enemyDie");
        }
    }

    /// <summary>
    /// Enemy die function
    /// </summary>
    void makeDead()
    {
        gameObject.SetActive(false);
        Instantiate(enemyHealthEF, transform.position, transform.rotation);
    }
}
