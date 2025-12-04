using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyScript : MonoBehaviour
{
    // Concept:
    // Enemy has a hitbox
    // Every time the Player enters the hitbox,
    // The enemy starts moving towards the player

    // Code linked to enemy

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player enters enemy range");
    }
}
