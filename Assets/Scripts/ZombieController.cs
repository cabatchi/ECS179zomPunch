using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float speed = 3f;
    public float health = 1f;
    private Transform target;
    private Animator animator;
    private List<Transform> zombies; // List of nearby zombies
    public float separationRadius = .1f; // Radius to detect nearby zombies for separation
    public float separationWeight = .001f; // Weight of separation behavior
    private ScoreManager scoreManager;
    private MoneyManager moneyManager;
    [SerializeField]
    private int dropMoneyOnDeath = 100;

    void Start()
    {
        // Find the player's transform using the tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        zombies = new List<Transform>();
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        moneyManager = GameObject.Find("GameManager").GetComponent<MoneyManager>();
    }

    void Update()
    {
        if (target != null && health > 0)
        {
            // Move the zombie towards the player
            Vector2 direction = (target.position - transform.position).normalized;
            Vector2 moveDirection = direction * speed * Time.deltaTime;

            // Apply flocking behavior
            Vector2 separation = Separate();
            moveDirection += (separation * separationWeight * Time.deltaTime);

            transform.Translate(moveDirection);
            animator.SetFloat("Speed", speed);
        }

        // Destroy zombie
    }

    Vector2 Separate()
    {
        Vector2 separation = Vector2.zero;

        foreach (Transform zombie in zombies)
        {
            if (zombie != null)
            {
                Vector2 toOther = transform.position - zombie.position;
                float distance = toOther.magnitude;
                if (distance < separationRadius)
                {
                    separation += toOther.normalized / distance;
                }
            }
        }

        return separation.normalized;
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
        moneyManager.AddMoney(dropMoneyOnDeath);
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
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController playerController = player.GetComponent<PlayerController>();
            float damage = playerController.damage;
            Debug.Log("Bullet -> Zombie" + damage);
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