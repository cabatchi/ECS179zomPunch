using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 200.0f; //Speed player will start with at the beginning of the game
    [SerializeField] private float rollCoolDown = 2.0f;
    [SerializeField] private float rollDistance = 20.0f;
    [SerializeField] private Animator animator;
    [SerializeField] private Health health;
    [SerializeField] private float stunDuration = 1.0f;
    private bool isStunned = false;

    enum PlayerStates { Normal, Rolling, Dead };
    private PlayerStates playerState;
    private float modifiedSpeed; // For later implemntation of powerups or slowdowns from enemies
    private Vector2 movementDirection;
    private float rollCooldownTimer;
    private Vector2 rollingDestination;
    //private GameObject player = getComponent<GameObject>();
    void Awake()
    {
        modifiedSpeed = baseSpeed;
        playerState = PlayerStates.Normal;
        rollCooldownTimer = rollCoolDown; //Player can roll at the start of the game, no need to wait
    }

    public void handlePunch() {
        Debug.Log("Punching");
    }

    public void handleRoll() {
        if(rollCooldownTimer >= rollCoolDown)
        {
            playerState = PlayerStates.Rolling;
            rollingDestination = gameObject.transform.position + (Vector3)movementDirection * rollDistance;
            rollCooldownTimer = 0.0f;
            Debug.Log("Begun Rolling");
            rolling();
        } else {
            Debug.Log("Roll is on cooldown");
        }

    }
    public void rolling(){
        if(Vector2.Distance(rollingDestination,(Vector2)gameObject.transform.position) < 0.4)
        {
            playerState = PlayerStates.Normal;
            return;
        }
        Vector2 newPosition = Vector2.Lerp(gameObject.transform.position, rollingDestination, 6.0f * Time.deltaTime);
        gameObject.transform.position = newPosition;
    }

    // public void KnockBack(Vector2 playerDirection, float knockBackForce) {
    //     // Calculate the knockback direction as the opposite of the player's direction
    //     Vector2 knockBackDirection = -playerDirection.normalized;

    //     Vector2 newPosition = Vector2.Lerp(gameObject.transform.position, knockBackDirection * knockBackForce, 6.0f * Time.deltaTime);
    //     gameObject.transform.position = newPosition;
    // }


    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); //Get input from player
        rollCooldownTimer += Time.deltaTime;
        if(playerState == PlayerStates.Dead)
        {
            return;
        }
        if(playerState == PlayerStates.Rolling)
        {
            rolling();
            return;
        }
        //Gets Movement Directions based on inputs
        if(Input.GetKeyDown(KeyCode.Space))
        {
            handleRoll();
        }
        if(Input.GetButton("Fire1"))
        {
            handleRoll();
        }
        gameObject.transform.Translate(movementDirection * Time.deltaTime * modifiedSpeed); //Basic movement
        animator.SetBool("Moving", movementDirection != Vector2.zero); //Enable or disable movement animation based on if there is input from player
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isStunned) 
        {
            health.TakeDamage(1);
            StunPlayer();
            Debug.Log("Damage Taken! Heahlth is " + health);
        } else {
            Debug.Log("Player is stunned");
        }
    }

    public void StunPlayer()
    {
        isStunned = true;
        StartCoroutine(UnStunAfterDelay(stunDuration));
    }

    private IEnumerator UnStunAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isStunned = false;
    }
}
