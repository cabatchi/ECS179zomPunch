using UnityEngine;

public class PowerUpDisplayController : MonoBehaviour
{
    public PlayerPowerUpsController playerPowerUpsController;

    public GameObject healthBuffDisplay;
    public GameObject damageBuffDisplay;
    public GameObject rangeBuffDisplay;
    public GameObject speedBuffDisplay;

    void Update()
    {
        int healthBuffCount = playerPowerUpsController.GetPowerUpCount(PowerUpType.HealthBuff);
        int damageBuffCount = playerPowerUpsController.GetPowerUpCount(PowerUpType.DamageBuff);
        int rangeBuffCount = playerPowerUpsController.GetPowerUpCount(PowerUpType.RangeBuff);
        int speedBuffCount = playerPowerUpsController.GetPowerUpCount(PowerUpType.SpeedBuff);

        healthBuffDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = healthBuffCount.ToString();
        damageBuffDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = damageBuffCount.ToString();
        rangeBuffDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = rangeBuffCount.ToString();
        speedBuffDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = speedBuffCount.ToString();
    }
}