using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliviaMoveset : MonoBehaviour
{
    private ProjectileShooter shootProjectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Slash attack
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Slash!");
        }

        // Laser attack
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Pew!");
        }
    }
}
