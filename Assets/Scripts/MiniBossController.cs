using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class MiniBossController : EnemyController
{
    public GameObject projectilePrefab;
    private bool shootingCoroutineStarted = false;

    // POLIMORPHISM
    protected override void AttackPlayer()
    {
        base.AttackPlayer();

        // no idea how to do it differently :) for now this is fine
        if (!shootingCoroutineStarted)
        {
            StartCoroutine(ShootProjectileCoroutine());
            shootingCoroutineStarted = true;
        }
        
    }

    private IEnumerator ShootProjectileCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            enemyRigidBody.velocity = Vector3.zero;
            yield return new WaitForSeconds(0.5f);
            this.transform.LookAt(player.transform);
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        Vector3 lookDirection = GetLookDirection();
        GameObject enemyProjectile = Instantiate(projectilePrefab, this.transform.position + (this.transform.forward * 2), this.transform.rotation);
        Rigidbody projectileRb = enemyProjectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(projectileRb.transform.forward * 500);
    }
}
