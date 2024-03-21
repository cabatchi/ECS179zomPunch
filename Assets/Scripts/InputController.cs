using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    public PlayerController playerController;
    public PlayerAttack playerAttack;
    public PauseMenuController pauseMenuController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuController.ToggleMenu();
        }

        if (!PauseMenuController.isPaused)
        {
            Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            playerController.HandleMove(movementDirection);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerAttack.UpdateWeaponCrosshair(mousePos);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                playerAttack.UseWeapon();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerController.HandleRoll();
            }
        }
    }
}