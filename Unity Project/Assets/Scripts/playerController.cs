using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {


    public float maxSpeed;
    public float jumpHeight;
    bool facingRight;
    bool grounded;
    bool crouching;

    //Declare a variable to fire
    public Transform gunTip;
    public Transform gunTipCrouching;
    public GameObject bullet;
    float fireRate = 0.5f; //fire per 0.5s
    float nextFire = 0; //fire immediately;

    Rigidbody2D myBody;
    Animator myAni;

    // Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D> ();
        myAni = GetComponent<Animator>();
        facingRight = true;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");
        myAni.SetFloat("Speed", Mathf.Abs(move));
        myAni.SetBool("Grounded", grounded);
        myAni.SetBool("Crouch", crouching);
        myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y);
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight) {
            flip();
        }
        if (Input.GetKey(KeyCode.W)){
            if (grounded){
                grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
            }
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            crouching = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            crouching = false;
        }
        //Fire by mouse
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            fireBullet();
        }
	}

    void flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    //Fire function
    void fireBullet() {
        if(Time.time > nextFire)
        {
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
            else if (!facingRight) {
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
