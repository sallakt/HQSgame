using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    // Bullet speed 
    public float bulletSpeed;
    // Bullet rigidbody component
    Rigidbody2D myBody;

    /// <summary>
    /// Adding force for the bullet
    /// </summary>
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            myBody.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            myBody.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Make the bullet stop function
    /// </summary>
    public void removeForce()
    {
        myBody.velocity = new Vector2(0, 0);
    }
}
