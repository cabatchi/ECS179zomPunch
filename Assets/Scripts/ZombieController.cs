using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float speed = 3f;
    public float health = 1f;
    private Transform target;
    private Animator animator;
    void Start()
    {
        // Find the player's transform using the tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (target != null)
        {
            // Move the zombie towards the player
            Vector2 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
            animator.SetFloat("Speed", speed);
        }

        // Destroy zombie
        if (health <= 0) 
        {
            Destroy(this);
        }
    }

     public void TakeDamage(float damage)
    {
        // Reduce health by the amount of damage taken
        health -= damage;

        // Ensure health doesn't go below 0
        health = Mathf.Max(health, 0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Weapon") 
        {
            Debug.Log("Sword -> Zombie");
            TakeDamage(1);
        }
        if (collider.gameObject.tag == "Bullet") 
        {
            Debug.Log("Bullet -> Zombie");
            TakeDamage(1);
        }
    }


}
