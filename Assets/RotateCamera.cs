using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 50;
   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        // Rotate method take a euler rotate around y-axis (Vector3.up)
        // Everytime the with the speed of 50
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);
       
    }
}
