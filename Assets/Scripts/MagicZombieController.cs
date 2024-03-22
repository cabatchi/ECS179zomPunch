using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicZombieController : MonoBehaviour
{   
    public float speed = 1f;
    public float health = 1f;
    private Transform target;
    private Animator animator;
    private ScoreManager scoreManager;
    private MoneyManager moneyManager;
    [SerializeField]
    private int dropMoneyOnDeath = 100;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBetweenShots;
    private float timeBetweenShots;
    public float retreatDistance;
    public GameObject shot;
    private bool isAttacking = false;
    
    void Start()
    {
        // Find the player's transform using the tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        moneyManager = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        timeBetweenShots = startTimeBetweenShots;
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
            if(isAttacking == false)
            {
                if (timeBetweenShots <= 0 && health > 0) 
                {
                    Debug.Log("Shot!");
                    StartCoroutine(StandStillAndShoot());
                    timeBetweenShots = startTimeBetweenShots;
                } 
                else 
                {
                    timeBetweenShots -= Time.deltaTime;
                }
            }
        }
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

    IEnumerator StandStillAndShoot()
    {
        // Stand still
        speed = 0;

        // Shoot projectile
        isAttacking = true;
        animator.SetBool("IsAttacking", true);
        Instantiate(shot, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1.1f); // Wait for the animation to finish
        animator.SetBool("IsAttacking", false);
        isAttacking = false;
        speed = 1; // Begin Moving again
    }
}