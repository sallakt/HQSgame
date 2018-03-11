using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    //Target character
    public Transform target;
    //Make the camera smoother 
    public float smoothing;
    //Offset distance between the player and camera 
    Vector3 offset;
    //Camera restraint
    public float lowY;

    /// <summary>
    /// Calculate offset, set lowY value
    /// </summary>
    void Start()
    {
        offset = transform.position - target.position;
        //lowY = transform.position.y;
    }

    // Calculate position for camera, and if character falls below lowY, camera stays at lowY 
    void Update()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        if (transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
