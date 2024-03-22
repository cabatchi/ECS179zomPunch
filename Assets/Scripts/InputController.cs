using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    public PlayerController playerController;
    public PlayerAttack playerAttack;
    public PauseMenuController pauseMenuController;
    public ItemShop itemShop;

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

            if (Input.GetKeyDown(KeyCode.I))
            {
                itemShop.ToggleShop();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && !itemShop.IsShopOpen())
            {
                playerAttack.UseWeapon();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space))
            {
                playerController.HandleRoll();
            }
        }
    }
}