using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public float maxHealth, currentHealth;

    //Enemy die effect
    public GameObject enemyHealthEF;
    //Enemyhealth UI
    public Slider enemyHealthSlider;
    //Declare Sound 
    public dieSoundManager dieSound;



    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
        dieSound = GameObject.FindGameObjectWithTag("DieSound").GetComponent<dieSoundManager>();
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void addDamage(float damage)
    {
        enemyHealthSlider.gameObject.SetActive(true);
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            makeDead();
            dieSound.Playsound("enemyDie");
        }
    }
    void makeDead()
    {
        gameObject.SetActive(false);
        Instantiate(enemyHealthEF, transform.position, transform.rotation);
    }
}
