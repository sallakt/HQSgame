using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {
    public float damage;
    float damageRate = 0.5f;
    public float pushBackForce; //set value
    float nextDamage;
	// Use this for initialization
	void Start () {
        nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            playerHealth thePlayerHealth = collision.gameObject.GetComponent<playerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = damageRate + Time.time;
            pushBack(collision.transform);
        }
    }

    //Create method to push the player back when touching the enemy
    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        //Debug.Log("push direction =" + pushDirection);
        pushDirection *= pushBackForce;
        Rigidbody2D pushRigidBody = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRigidBody.velocity = new Vector2(0,0);
        pushRigidBody.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
