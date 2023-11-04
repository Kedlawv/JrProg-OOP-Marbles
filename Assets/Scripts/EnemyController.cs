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
        Vector3 lookDirection = (player.transform.position - this.transform.position).normalized;
        enemyRigidBody.AddForce(lookDirection * speed);

        if(this.transform.position.y < deathYPos)
        {
            Destroy(this.gameObject);
        }
    }
}
