using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float meleeSpeed;

    [SerializeField] private float damage;

    float timeUntilMelee;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Pressed K ");
            anim.SetTrigger("Attack");
        }
    }
}