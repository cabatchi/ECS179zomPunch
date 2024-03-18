using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float baseSpeed = 200.0f; //Speed player will start with at the beginning of the game
    [SerializeField] private float rollCoolDown = 2.0f;
    [SerializeField] private float rollDistance = 20.0f;
    [SerializeField] private Animator animator;
    [SerializeField] private Health health;
    [SerializeField] public float damage = 1;
    [SerializeField] private float stunDuration = 1.0f;
    [SerializeField] private PlayerAttack weapon;

    enum PlayerStates { Normal, Rolling, Stunned, Dead };
    private PlayerStates playerState;
    public float modifiedSpeed; // For later implemntation of powerups or slowdowns from enemies
    private Vector2 movementDirection;
    private float rollCooldownTimer;
    private Vector2 rollingDestination;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    void Awake()
    {
        modifiedSpeed = baseSpeed;
        playerState = PlayerStates.Normal;
        rollCooldownTimer = rollCoolDown; //Player can roll at the start of the game, no need to wait
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        damage = 1;
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
            Debug.Log("Begun Rolling");
            playerState = PlayerStates.Rolling;
            rollingDestination = gameObject.transform.position + (Vector3)movementDirection * rollDistance;
            rollCooldownTimer = 0.0f;
            animator.SetBool("Rolling", true);
            rolling();
        }
        else
        {
            Debug.Log("Roll is on cooldown");
        }

    }
    public void rolling()
    {
        if (Vector2.Distance(rollingDestination, (Vector2)gameObject.transform.position) < 0.1)
        {
            playerState = PlayerStates.Normal;
            animator.SetBool("Rolling", false);
            return;
        }
        Vector2 newPosition = Vector2.Lerp(gameObject.transform.position, rollingDestination, 6.0f * Time.deltaTime);
        gameObject.transform.position = newPosition;
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
    }

    void setDirectionPlayer() {
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
            }
        }
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
}
