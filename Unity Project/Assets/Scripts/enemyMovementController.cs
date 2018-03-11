using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour
{
    // Speed of enemy
    public float enemySpeed;
    // Enemy rigidbody component
    Rigidbody2D enemyRB;
    // Enemy animator component
    Animator enemyAni;
    // Enemy graphic object
    public GameObject enemyGraphic;
    // Facing right boolean
    bool facingRight = true;
    // Enemy facing time 
    float facingTime = 5f;
    // Enemy next flip time
    float nextflip = 0f;
    // Can flip boolean 
    bool canFlip = true;

    /// <summary>
    /// Get component for enemyRB and enemyAni
    /// </summary>
    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAni = GetComponentInChildren<Animator>();
    }
    // Use this for initialization
    void Start()
    {

    }


    /// <summary>
    /// Calculating next flip, make enemy flip after 5s
    /// </summary>
    void Update()
    {
        if (Time.time > nextflip)
        {
            nextflip = Time.time + facingTime;
            flip();
        }
    }

    /// <summary>
    /// When player enter 2D box collider:
    /// Flip when: - enemy is facing right and player is on the left of enemy or
    ///            - enemy is facing left and character is on the left of enemy  
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (facingRight && collision.transform.position.x < transform.position.x)
            {
                flip();
            }
            else if (!facingRight && collision.transform.position.x > transform.position.x)
            {
                flip();
            }
            canFlip = false;
        }
    }

    /// <summary>
    /// Make enemy run when character stays in the collision zone
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!facingRight)
            {
                enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            }
            else { enemyRB.AddForce(new Vector2(1, 0) * enemySpeed); }
            enemyAni.SetBool("Run", true);
        }
    }


    /// <summary>
    /// Enemy stops when player exit collision zone 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canFlip = true;
        }
        enemyRB.velocity = new Vector2(0, 0);
        enemyAni.SetBool("Run", false);
    }

    /// <summary>
    /// Flip funtion, flip enemy 180 degrees
    /// </summary>
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
