using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    public PlayerController playerController;

    void Update()
    {
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        playerController.HandleMove(movementDirection);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.HandleRoll();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            playerController.UseWeapon();
        }
    }
}