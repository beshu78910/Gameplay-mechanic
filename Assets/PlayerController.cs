using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    private float speed = 20;
    public GameObject focalPoint;
    public bool hasPowerUp;
    private Rigidbody enemyRb;
    private float powerIncrease = 8;
    public GameObject powerIndicator;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * 10 , ForceMode.Impulse);
        }

        // Set the position of the indicator = to the position of the player 
        // Adjusting the Vector by -0.5f according to y position
        powerIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);
    }


    // When a game object collides with another gameobject unity calls on OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerUpCountDown());
           
        }
    }

    // Create an IEnumerator to disable the effect of powerUp after 7 second
    IEnumerator PowerUpCountDown()
    {
        // return the result after 7 second
        yield return new WaitForSeconds(7);
        // disable power Up
        hasPowerUp = false;
        powerIndicator.gameObject.SetActive(false);
    }

    // OnCollisionEnter is called when a collider/rigidbody collie with another collider/rigidbody
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            // assign the EnemyRb equal to the other collision object that colldies with player
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            // Calculate the distance that enemy move away from the player, the opposite of enemy follow player
            Vector3 awayFromPlayer = other.transform.position - transform.position;
            // Mutiple that with the force to pushed enemy away
            enemyRb.AddForce(awayFromPlayer * powerIncrease, ForceMode.Impulse);
            Debug.Log("Collided with: " + other.gameObject.name + " with powerup set to" + hasPowerUp);
            
        }
    }
}
