using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    private float speed = 20;
    public GameObject focalPoint;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        // find the game Object FocalPoint in game hierachy and assign it to focalPoint variable
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        // float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        // Switch the Vector3.forward (global position) to the focalPoint.transform.forward (local position of Focal Point)
        // Game object
        playerRb.AddForce(focalPoint.transform.forward * Time.deltaTime * speed * verticalInput, ForceMode.Impulse);
        // playerRb.AddForce(Vector3.right * Time.deltaTime * speed * horizontalInput, ForceMode.Impulse);
    }
}
