using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 0.3f;
    public bool rotate = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() //use for constant updates
    {
        if (rotate)
        {
            this.GetComponent<Transform>().Rotate(0, rotationSpeed, 0);
        }
    }
}
