using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    private Rigidbody rigidBody;
    private GameObject focalPoint;
    public bool hasPowerup;
    public float powerUpStreangth = 15;
    public PowerUpIndicator powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        rigidBody.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerupIndicator.Position = this.transform.position + new Vector3(0, -0.5f, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigidBody.angularDrag = 4;
            this.rigidBody.drag = 4;
        } else if (Input.GetKeyUp(KeyCode.Space))
        {
            this.rigidBody.angularDrag = 0.5f;
            this.rigidBody.drag = 0.2f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup") && !hasPowerup)
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.Active = true;
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
        
        // create a script for powerup indicator holding the Active bool and make this Encapsulation example
        powerupIndicator.Active = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.transform.position - this.transform.position;
            enemyRigidBody.AddForce(awayFromPlayer * powerUpStreangth, ForceMode.Impulse);
            // Debug.Log("Player collided with " + collision.gameObject.name + " and payer hasPowerup is " + hasPowerup);
        }
    }
}
