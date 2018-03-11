using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    // Enemy damage value declare
    public float damage;
    // Damage rate declare
    float damageRate = 0.5f;
    // Push back delare
    public float pushBackForce;
    // Next damage time declare
    float nextDamage;

    /// <summary>
    /// Set initial next damage value
    /// </summary>
	void Start()
    {
        nextDamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Enemy collides character function, push back function call
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            playerHealth thePlayerHealth = collision.gameObject.GetComponent<playerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = damageRate + Time.time;
            pushBack(collision.transform);
        }
    }

    /// <summary>
    /// Create method to push the player back when touching the enemy
    /// </summary>
    /// <param name="pushedObject"></param>
    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRigidBody = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRigidBody.velocity = new Vector2(0, 0);
        pushRigidBody.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
