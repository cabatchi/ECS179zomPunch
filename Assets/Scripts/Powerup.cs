using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffect powerupEffect;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with powerup");
            Destroy(gameObject);
            powerupEffect.Apply(collision.gameObject);
        }
    }
}
