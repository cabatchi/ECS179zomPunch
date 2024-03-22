using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherZombieController : MonoBehaviour
{   
    public float speed = 3f;
    public float health = 1f;
    private Transform target;
    private Animator animator;
    private List<Transform> zombies; // List of nearby zombies
    public float separationRadius = .1f; // Radius to detect nearby zombies for separation
    public float separationWeight = .001f; // Weight of separation behavior
    private ScoreManager scoreManager;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBetweenShots;
    public float projectileTime;
    private float timeBetweenShots;
    public float retreatDistance;
    public GameObject shot;
    public float healthScalingFactor = 1.2f;
    public float speedScalingFactor = 1.1f;

    void Start()
    {
        // Find the player's transform using the tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        zombies = new List<Transform>();
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        timeBetweenShots = startTimeBetweenShots;
        float healthMultiplier = Mathf.Pow(healthScalingFactor, ZombieSpawner.currentWave - 1);
        float speedMultiplier = Mathf.Pow(speedScalingFactor, ZombieSpawner.currentWave - 1);

        // Apply scaled health and speed
        health *= healthMultiplier;
        speed *= speedMultiplier;
    }

    void Update()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < nearDistance) 
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, target.position) > stoppingDistance) 
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance) 
            {
                this.transform.position = transform.position;
            }

            animator.SetFloat("Speed", speed);

            // Instantiate(shot, transform.position, Quaternion.identity);
            if (timeBetweenShots <= 0 && health > 0) 
            {
                Debug.Log("Shot!");
                Instantiate(shot, transform.position, Quaternion.identity);
                timeBetweenShots = startTimeBetweenShots;
            } 
            else 
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }

        // Destroy zombie
    }


    public void TakeDamage(float damage)
    {
        // Reduce health by the amount of damage taken
        health -= damage;

        // Ensure health doesn't go below 0
        health = Mathf.Max(health, 0);

        if (health <= 0)
        {
            Destroy(gameObject.GetComponent<BoxCollider2D>()); //Removes collision so that the zombie can't damage the player after it's dead
            OnDied();
        }
    }

    void OnDied()
    {
        speed = 0;
        animator.SetBool("IsDead", true);
        scoreManager.AddScore(100);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Weapon")
        {
            // Debug.Log("Sword -> Zombie");
            TakeDamage(1);
        }
        if (collider.gameObject.tag == "Bullet")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController playerController = player.GetComponent<PlayerController>();
            float damage = playerController.damage;
            // Debug.Log("Bullet -> Zombie" + damage);
            TakeDamage(damage);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            zombies.Add(other.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            zombies.Remove(other.transform);
        }
    }
}