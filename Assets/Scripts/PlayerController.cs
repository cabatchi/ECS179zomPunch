using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float baseSpeed = 200.0f; //Speed player will start with at the beginning of the game
    [SerializeField] private float rollCoolDown = 2.0f;
    [SerializeField] private float rollDistance = 20.0f;
    [SerializeField] private Animator animator;
    [SerializeField] private Health health;
    [SerializeField] public float damage = 0.5f;
    [SerializeField] private float stunDuration = 1.0f;
    [SerializeField] private PlayerAttack weapon;
    [SerializeField] private float timeBeforeHealingStarts = 5.0f; 
    [SerializeField] private float healingInterval = 2.0f; 
    [SerializeField] private int healAmount = 1; 

    enum PlayerStates { Normal, Rolling, Stunned, Dead };
    private PlayerStates playerState;
    public float modifiedSpeed; // For later implemntation of powerups or slowdowns from enemies
    private Vector2 movementDirection;
    private float rollCooldownTimer;
    private Vector2 rollingDestination;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    private GameManager gameManager;
    private PlayerPowerUpsController powerUpsController;
    private Rigidbody2D rb;
    private Coroutine healingCoroutine;
    private bool canHeal = false;
    private float lastHitTime = 0f;
    void Awake()
    {
        modifiedSpeed = baseSpeed;
        playerState = PlayerStates.Normal;
        rollCooldownTimer = rollCoolDown; //Player can roll at the start of the game, no need to wait
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        damage = 1;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        powerUpsController = FindObjectOfType<PlayerPowerUpsController>();
        if (powerUpsController != null)
        {
            healingCoroutine = StartCoroutine(HealOverTime());
        }
    }

    public void HandleMove(Vector2 movementDirection)
    {
        this.movementDirection = movementDirection;
    }

    public void HandlePunch()
    {
        Debug.Log("Punching");
    }
    public void HandleRoll()
    {
        if (rollCooldownTimer >= rollCoolDown && playerState == PlayerStates.Normal)
        {
            // Check if the player is not colliding with an object tagged as "Boundary"
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(1f, 1f), 0f);
            bool canRoll = true;
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Boundary"))
                {
                    // If colliding with a "Boundary" object, prevent rolling
                    canRoll = false;
                    Debug.Log("Cannot roll because of the boundary.");
                    break;
                }
            }

            // If not colliding with a "Boundary" object, initiate the roll
            if (canRoll)
            {
                Debug.Log("Begun Rolling");
                playerState = PlayerStates.Rolling;
                rollingDestination = transform.position + (Vector3)movementDirection * rollDistance * modifiedSpeed;
                rollCooldownTimer = 0.0f;
                animator.SetBool("Rolling", true);
                rolling();
            }
        }
        else
        {
            Debug.Log("Roll is on cooldown or player is not in normal state.");
        }
    }
    public void rolling()
    {
        Vector2 newPosition = Vector2.Lerp(gameObject.transform.position, rollingDestination, 6.0f * Time.deltaTime);
        gameObject.transform.position = newPosition;
        if (Vector2.Distance(rollingDestination, (Vector2)gameObject.transform.position) < 0.1)
        {
            playerState = PlayerStates.Normal;
            animator.SetBool("Rolling", false);
            return;
        }
    }

    void Update()
    {
        rollCooldownTimer += Time.deltaTime;
        if (playerState == PlayerStates.Dead)
        {
            return;
        }
        if (playerState == PlayerStates.Rolling)
        {
            rolling();
            return;
        }
        if (playerState == PlayerStates.Stunned)
        {
            return;
        }
        setDirectionPlayer();
        gameObject.transform.Translate(movementDirection * Time.deltaTime * modifiedSpeed); //Basic movement
        animator.SetFloat("Speed", movementDirection.magnitude); //Enable or disable movement animation based on if there is input from player

        if (health.health <= 0)
        {
            playerState = PlayerStates.Dead;
            onDeath();
        }
    }

    void setDirectionPlayer()
    {
        if (movementDirection.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movementDirection.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    public void UseWeapon()
    {
        damage += 1;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Player has collided with an enemy");
            if (playerState != PlayerStates.Rolling) //Player can't take damage while rolling
            {
                StartCoroutine(FlashRed());
                health.TakeDamage(1);
                StunPlayer();
                Debug.Log("Damage Taken! Health is " + health);
                lastHitTime = Time.time;
            }
        }
        if (collider.gameObject.tag == "EnemyBullet")
        {
            Debug.Log("Player has collided with an enemy bullet");
            if (playerState != PlayerStates.Rolling) //Player can't take damage while rolling
            {
                StartCoroutine(FlashRed());
                health.TakeDamage(1);
                StunPlayer();
                Debug.Log("Damage Taken! Health is " + health);
                lastHitTime = Time.time;
            }
        }
        if (collider.gameObject.CompareTag("Boundary") && playerState == PlayerStates.Normal)
        {
            Debug.Log("Tried getting out of map...");
            // Reverse the direction of rolling
            movementDirection *= -1;
            rollingDestination = (Vector2)transform.position + movementDirection * rollDistance * modifiedSpeed *1/10;
        }
        if (collider.gameObject.CompareTag("Boundary") && playerState == PlayerStates.Rolling)
        {
            Debug.Log("Hit wall while rolling...");
            // Reverse the direction of rolling
            movementDirection *= -1;
            rollingDestination = (Vector2)transform.position + movementDirection * rollDistance * modifiedSpeed *1/10;
        }
    }

    private void onDeath()
    {
        gameManager.TriggerGameOver();
    }

    public void StunPlayer()
    {
        playerState = PlayerStates.Stunned;
        StartCoroutine(UnStunAfterDelay(stunDuration));
    }

    private IEnumerator UnStunAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerState = PlayerStates.Normal;
    }

    private IEnumerator FlashRed()
    {
        // Change the color to red
        spriteRenderer.color = Color.red;

        // Wait for a short duration
        yield return new WaitForSeconds(0.1f);

        // Change the color back to white (assuming the default color is white)
        spriteRenderer.color = Color.white;
    }

    IEnumerator HealOverTime()
    {
        float timeBeforeHealingStartsNew = timeBeforeHealingStarts / (powerUpsController.GetPowerUpCount(PowerUpType.HealthBuff) + 1);

        yield return new WaitForSeconds(timeBeforeHealingStartsNew);
        // Debug.Log(powerUpsController.GetPowerUpCount(PowerUpType.HealthBuff) + 1);

        canHeal = true;

        while (true)
        {
            if (canHeal && Time.time - lastHitTime > timeBeforeHealingStartsNew)
            {
                // Increment health by healAmount
                health.health += healAmount;

                // Ensure health doesn't exceed the maximum number of hearts
                health.health = Mathf.Min(health.health, health.numOfHearts);
            }

            yield return new WaitForSeconds(healingInterval);
        }
    }

    private void empty() 
    {
        timeBeforeHealingStarts += 0.0001f;
    }

}
