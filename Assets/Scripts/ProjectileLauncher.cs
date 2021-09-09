using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform target;
    public Rigidbody projectile;
    public float projectileTime;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            LaunchProjectile();
        }
    }

    public void LaunchProjectile()
    {
        Vector3 displacement = target.position - transform.position;
        Vector3 acceleration = Physics.gravity;
        float time = projectileTime;
        Vector3 initialVelocity = FindInitialVelocity(displacement, acceleration, time);
        Vector3 finalVelocity = FindFinalVelocity(initialVelocity, acceleration, time);

        Rigidbody projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
        projectileInstance.AddForce(initialVelocity, ForceMode.VelocityChange);
    }

    private Vector3 FindFinalVelocity(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        //v = v0 + at
        Vector3 finalVelocity = initialVelocity + acceleration * time;

        return finalVelocity;
    }

    private Vector3 FindDisplacement(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        //deltaX = v0 * t + (1/2)*a*t^2
        Vector3 displacement = initialVelocity * time + (1 / 2) * acceleration * time * time;

        return displacement;
    }

    private Vector3 FindInitialVelocity(Vector3 displacement, Vector3 acceleration, float time)
    {
        //delta = v0 * t + (1/2)*a*t^2
        //delta - (1/2)*a*t^2 = v0 * t 
        //delta/t - (1/2)*a*t^2 = v0
        //v0 = delta/t - (1/2)*a*t^2
        Vector3 initialVelocity = displacement / time - 0.5f * acceleration * time;

        return initialVelocity;
    }
}
