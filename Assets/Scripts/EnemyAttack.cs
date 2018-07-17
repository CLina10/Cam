using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public float attackDistance = 1.5f;
    public Transform target;

    GameObject player;
    PlayerController playerHealth;
    EnemyBehaviour health;
    bool playerInRange;
    float timer;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerController>();
        health = GetComponent<EnemyBehaviour>();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) > attackDistance)
        {
            playerInRange = false;
        }
        else
        {
            playerInRange = true;
            transform.LookAt(target);
        }

        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && health.currenthealth > 0)
        {
            Attack();
        }

        if(playerHealth.currentHealth <= 0)
        {
            Destroy(player);
            Application.Quit();
        }
    }

    void Attack()
    {
        timer = 0f;

        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward;

        Destroy(bullet, 1f);

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
