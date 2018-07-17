using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public float acceleration = 10f;
    public float friction = 10f;
    public float rotationSmoothtime = 1f;
    public Transform body;
    Vector3 moveVector;
    Vector3 velocity;

    public const float playerHealth = 50f;
    public float currentHealth = playerHealth;

    void Start()
    {
        velocity = Vector3.zero;
    }

    void Update()
    {
        Move();
        Rotation();
    }

    void Move()
    {
        Vector3 moveX = transform.right * Input.GetAxis("Horizontal");
        Vector3 moveZ = transform.forward * Input.GetAxis("Vertical");
        moveVector = moveX + moveZ;
        velocity += moveVector * acceleration * Time.deltaTime;
        transform.position += velocity * speed * Time.deltaTime;
        velocity -= friction * Time.deltaTime * velocity;
    }

    void Rotation()
    {
        float xRot = Input.GetAxis("Horizontal2");
        if (Mathf.Abs(xRot) > 0.001f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.right * xRot, Vector3.up), Time.deltaTime * rotationSmoothtime);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Health:" + currentHealth);
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
