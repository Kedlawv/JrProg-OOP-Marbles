using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    protected Rigidbody enemyRigidBody;
    protected GameObject player;

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
        
        AttackPlayer();

        OutOfBoundsCheck();
    }

    protected Vector3 GetLookDirection()
    {
        return (player.transform.position - this.transform.position).normalized;
    }

    protected virtual void AttackPlayer()
    {
        Vector3 lookDirection = GetLookDirection();
        enemyRigidBody.AddForce(lookDirection * speed);
    }

    private void OutOfBoundsCheck()
    {
        if (this.transform.position.y < deathYPos)
        {
            Destroy(this.gameObject);
        }
    }
}
