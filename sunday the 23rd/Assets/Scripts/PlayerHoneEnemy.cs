using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoneEnemy : MonoBehaviour
{
    [Tooltip("How far away talking is allowed to happen")]
    public float minPlayerDistance;
    [Tooltip("The object to measure distance against. Usually the player")]
    public Transform target;

    public float speed;
    private SpriteRenderer spriteRenderer;
    private Mover controlledMover;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minPlayerDistance);
    }

    void Start()
    {
        //Set reference vars
        spriteRenderer = GetComponent<SpriteRenderer>();
        controlledMover = GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        //If we have a target (the player)
        if (target)
        {
            //If we are close enough...
            if (IsWithinDistance(minPlayerDistance))
            {
                //Go towards player
                Debug.Log("Move towards player");
                MoveTowardsPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        //controlledMover.AccelerateInDirection(new Vector3(-1f, 0f, 0f));
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }

    public virtual bool IsWithinDistance(float distance)
    {
        //Check if we're close enough to the target
        return (GetDirection().magnitude < distance);
    }

    public virtual Vector3 GetDirection()
    {
        //Get the direction of the target
        return target.position - transform.position;
    }
}
