using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Player max speed
    public float maxSpeed;
    // Player jump height
    public float jumpHeight;
    // Player facing right boolean
    bool facingRight;
    // Player ground boolean
    bool grounded;
    // Player crouch boolean
    bool crouching;
    // Gun tip when stand
    public Transform gunTip;
    // Gun tip when crouch
    public Transform gunTipCrouching;
    // Bullet object
    public GameObject bullet;
    // Fire per 0.5s
    float fireRate = 0.5f;
    // Fire immediately;
    float nextFire = 0;
    // Declare sound for character
    public characterSoundManager characterSound;
    // Box collider of the character
    BoxCollider2D boxcld;
    // Character Rigidbody2D component
    Rigidbody2D myBody;
    // Character animator component
    Animator myAni;
    // List of collider 
    public List<Collider2D> touchingCollider = new List<Collider2D>();

    /// <summary>
    /// Get component for myBody, myAni, characterSound
    /// Set character facing right boolean true
    /// </summary>
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAni = GetComponent<Animator>();
        facingRight = true;
        characterSound = GameObject.FindGameObjectWithTag("CharacterSound").GetComponent<characterSoundManager>();
    }

    /// <summary>
    /// Character controller
    /// </summary>
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        myAni.SetFloat("Speed", Mathf.Abs(move));
        myAni.SetBool("Grounded", grounded);
        myAni.SetBool("Crouch", crouching);
        if (!crouching)
        {
            myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y);
        }
        if (crouching && grounded)
        {
            myBody.velocity = Vector2.zero;
        }
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }
        // Press W and add force for character to jump, play jump sound
        if (Input.GetKey(KeyCode.W))
        {
            if (grounded)
            {
                grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
                characterSound.Playsound("jump");
            }
        }
        boxcld = GetComponent<BoxCollider2D>();
        // Press S key and decrease box collider
        if (Input.GetKeyDown(KeyCode.S))
        {
            crouching = true;
            boxcld.size = new Vector2(5.29f, 8);
        }
        // Release S key and increase box collider
        if (Input.GetKeyUp(KeyCode.S))
        {
            crouching = false;
            boxcld.size = new Vector2(5.29f, 10.79f);
        }
        // Fire by mouse
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            fireBullet();
        }
        // Interact with the switch
        if (Input.GetKeyDown(KeyCode.E) && touchingCollider.Count > 0)
        {
            //touchingCollider.ForEach(n => n.SendMessage("Use", SendMessageOptions.DontRequireReceiver));
            foreach (Collider2D n in touchingCollider)
            {
                n.gameObject.SendMessage("Use", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    /// <summary>
    /// Character flip function
    /// </summary>
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //moving along with moving platform
        if (other.gameObject.tag == "Moving Platform")
        {
            grounded = true;
            transform.parent = other.transform;
        }
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    /// <summary>
    /// Stop moving with the platform when not on it
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Moving Platform")
        {
            transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Switch")
        {
            touchingCollider.Add(col);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Switch")
        {
            touchingCollider.Remove(col);
        }
    }


    /// <summary>
    /// Fire function
    /// </summary>
    void fireBullet()
    {
        if (Time.time > nextFire)
        {
            characterSound.Playsound("shoot");
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                if (crouching == true)
                {
                    Instantiate(bullet, gunTipCrouching.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else
                {
                    Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
            }
            else if (!facingRight)
            {
                if (crouching == true)
                {
                    Instantiate(bullet, gunTipCrouching.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                }
                else
                {
                    Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                }
            }
        }
    }
}
