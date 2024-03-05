using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;

    void Start()
    {
        // Find the player's transform using the tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (target != null)
        {
            // Move the zombie towards the player
            Vector2 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
