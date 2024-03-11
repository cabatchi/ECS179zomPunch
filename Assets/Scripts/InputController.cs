using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    public PlayerController playerController;
    public PlayerAttack playerAttack;

    void Update()
    {
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerController.HandleMove(movementDirection);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerAttack.UpdateWeaponCrosshair(mousePos);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.HandleRoll();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAttack.UseWeapon();
        }
    }
}