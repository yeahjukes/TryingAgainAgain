using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject tempProjectile;
    public Transform spawnPoint;
    private Vector3 direction;

    // Start is called before the first frame update
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    public void Fire()
    {
        GameObject newProjectile = new GameObject();

        if (tempProjectile != null)
        {
            newProjectile = Instantiate(tempProjectile) as GameObject;
            tempProjectile = null;
        }
        else
        {
            newProjectile = Instantiate(projectilePrefab) as GameObject;
        }

        newProjectile = Instantiate(projectilePrefab) as GameObject;

        newProjectile.transform.position = spawnPoint.position;

        ProjectileController newProjectileController = newProjectile.GetComponent<ProjectileController>();
    
        if (newProjectileController != null )
        {
            newProjectileController.Setup(direction);
        }
        else
        {
            Debug.LogWarning("Projectile is missing a projectile controller");
        }
    }
}
