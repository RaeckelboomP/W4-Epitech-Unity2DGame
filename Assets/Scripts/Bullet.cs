using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public int damage = 5;
    public float maxDistance = 10;
    private Vector2 startPosition;
    private float travelledDistance = 0;
    private Rigidbody2D rb2d;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Initialize() {
        startPosition = transform.position;
        rb2d.velocity = transform.up * speed;
    }

    private void Update() {
        travelledDistance = Vector2.Distance(transform.position, startPosition);
        if (travelledDistance >= maxDistance) {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Collider" + collision.name);

        var damageable = collision.GetComponent<Damageable>();
        if(damageable != null) {
            damageable.Hit(damage);
        }

        DisableObject();
    }
}
