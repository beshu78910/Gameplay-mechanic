using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 1.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    private Vector3 lookDirection;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // The vector that needed for enemy to follow Player is calculated by subtract 
        // the player position to the enemy position 
        // The furter the player from the enemy position distance will increase, which increase in force over time
        // Normalized normalize the magitude => keep the same speed even if distance increase
        Vector3 lookDirection = ((player.transform.position - transform.position).normalized * speed);
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);

        if (enemyRb.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}