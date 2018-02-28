using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour {
    public float enemySpeed;
    Rigidbody2D enemyRB;
    Animator enemyAni;
    public GameObject enemyGraphic;
    bool facingRight = true;
    float facingTime = 5f;
    float nextflip = 0f;
    bool canFlip = true;

    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAni = GetComponentInChildren<Animator>();
    }
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Time.time > nextflip)
        {
            nextflip = Time.time + facingTime;
            flip();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(facingRight && collision.transform.position.x < transform.position.x)
            {
                flip();
            }
            else if(!facingRight && collision.transform.position.x > transform.position.x)
            {
                flip();
            }
            canFlip = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!facingRight)
            {
                enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            }
            else { enemyRB.AddForce(new Vector2(1, 0) * enemySpeed); }
            enemyAni.SetBool("Run", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canFlip = true;
        }
        enemyRB.velocity = new Vector2(0, 0);
        enemyAni.SetBool("Run", false);
    }

    void flip()
    {
        if (!canFlip)
            return;
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }
}
