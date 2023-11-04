using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody enemyRigidBody;
    private GameObject player;

    private float deathYPos = -5;
    


    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // abstract to Look At Player and move to parrent class. Abstraction example
        Vector3 lookDirection = (player.transform.position - this.transform.position).normalized;
        
        // abstract out to AttackPlayer and make virtual
        // override in the Boss class. Polymorfism example. Inheritance Example.
        enemyRigidBody.AddForce(lookDirection * speed);

        // abstract out to OutOfBounds and move to parrent class
        if(this.transform.position.y < deathYPos)
        {
            Destroy(this.gameObject);
        }
    }
}
