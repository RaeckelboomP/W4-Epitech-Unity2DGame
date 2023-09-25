using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankController : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    private Vector2 movementVector;
    public float maxSpeed = 10;
    public float rotationSpeed = 100;
    public float turretRotationSpeed = 150;

    public Transform turretParent;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void HandleShoot()
    {
        Debug.Log("Shooting");
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        // try to change Vector3 to Vector2 after test
        var turretDirection = (Vector3)pointerPosition - turretParent.position;

        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg; //Mathf.Rad2Deg convert Radiants to Degrees

        var rotationStep = turretRotationSpeed * Time.deltaTime;

        turretParent.rotation = Quaternion.RotateTowards(turretParent.rotation, Quaternion.Euler(0, 0, desiredAngle-90), rotationStep);
    }

    private void FixedUpdate()
    {
        rigidBody2D.velocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;
        rigidBody2D.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
