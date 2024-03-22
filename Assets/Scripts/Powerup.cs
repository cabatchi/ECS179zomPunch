using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffect powerupEffect;
    public GameObject floatingTextPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with powerup");
            Destroy(gameObject);
            PowerUpType powerUpType = powerupEffect.GetPowerUpType();

            GameObject target = collision.gameObject;
            target.GetComponent<PlayerPowerUpsController>().AddPowerUp(powerUpType);
            FindObjectOfType<SoundManager>().PlaySoundEffect("PowerUp");
            
            powerupEffect.Apply(target);
            // Instantiate floating text
            GameObject text = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            text.GetComponent<TextMesh>().text = "+" + powerUpType.ToString();
        }
    }
}
