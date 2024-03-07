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
    [SerializeField] private PlayerAttack weapon;
    private bool isStunned = false;

    enum PlayerStates { Normal, Rolling, Stunned, Dead };
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
        if(playerState == PlayerStates.Stunned)
        {
            rolling();
            return;
        }
        //Roll in direction of player input
        if(Input.GetKeyDown(KeyCode.Space))
        {
            handleRoll();
        }
        gameObject.transform.Translate(movementDirection * Time.deltaTime * modifiedSpeed); //Basic movement
        animator.SetBool("Moving", movementDirection != Vector2.zero); //Enable or disable movement animation based on if there is input from player

        if (Input.GetKeyDown(KeyCode.J)) 
        {
            useWeapon();
        }
    }
    public void useWeapon() 
    {
        // if (weapon != null) 
        // {
        //     Instantiate(weapon);
        // }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy") 
        {
            Debug.Log("Player has collided with an enemy");
            if (!isStunned) 
            {
                health.TakeDamage(1);
                StunPlayer();
                Debug.Log("Damage Taken! Health is " + health);
            } else {
                Debug.Log("Player is stunned");
            }
        }
    }

    public void StunPlayer()
    {
        isStunned = true;
        playerState = PlayerStates.Stunned;
        StartCoroutine(UnStunAfterDelay(stunDuration));
    }

    private IEnumerator UnStunAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerState = PlayerStates.Normal;
        isStunned = false;
    }
}
