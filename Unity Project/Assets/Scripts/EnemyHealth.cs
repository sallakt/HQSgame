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

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
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
        }
    }
    void makeDead()
    {
        gameObject.SetActive(false);
        Instantiate(enemyHealthEF, transform.position, transform.rotation);
    }
}
