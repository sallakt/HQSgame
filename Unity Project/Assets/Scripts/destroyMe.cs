using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyMe : MonoBehaviour
{
    // Time to stay alive
    public float aliveTime;

    /// <summary>
    /// Destroy function
    /// </summary>
    void Start()
    {
        Destroy(gameObject, aliveTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
