using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurret : MonoBehaviour
{
    public float turretRotationSpeed = 150;

    public void Aim(Vector2 inputPointerPosition) {
        
        var turretDirection = inputPointerPosition - (Vector2)transform.position;
        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg; //Mathf.Rad2Deg convert Radiants to Degrees
        var rotationStep = turretRotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle-90), rotationStep);
    }

}
