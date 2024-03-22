using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemShop : MonoBehaviour
{
    [SerializeField] public Canvas canvas;
    [SerializeField] private TextMeshProUGUI powerUp1PriceText;
    [SerializeField] private TextMeshProUGUI powerUp2PriceText;
    [SerializeField] private TextMeshProUGUI powerUp3PriceText;
    [SerializeField] private TextMeshProUGUI powerUp4PriceText;

    [SerializeField] private Button powerUp1Button;
    [SerializeField] private Button powerUp2Button;
    [SerializeField] private Button powerUp3Button;
    [SerializeField] private Button powerUp4Button;

    private int powerUp1Price = 100;
    private int powerUp2Price = 150;
    private int powerUp3Price = 200;
    private int powerUp4Price = 250;

    private float priceMultiplier = 1.2f;
    private ScoreManager scoreManager;
    private PlayerPowerUpsController powerUpsController;

    void Start()
    {
        canvas.enabled = false;
        scoreManager = FindObjectOfType<ScoreManager>();
        powerUpsController = FindObjectOfType<PlayerPowerUpsController>();
        UpdatePowerUpPrices();
        powerUp1Button.onClick.AddListener(UpgradePowerUp1);
        powerUp2Button.onClick.AddListener(UpgradePowerUp2);
        powerUp3Button.onClick.AddListener(UpgradePowerUp3);
        powerUp4Button.onClick.AddListener(UpgradePowerUp4);
    }

    void Update()
    {
        if (!ZombieSpawner.waveIsDone)
        {
            // Close the item shop if the wave is no longer done
            canvas.enabled = false;
        } else 
        {
            canvas.enabled = true;
        }
    }
    public void UpgradePowerUp1()
    {
        if (ScoreManager.GetScore() >= powerUp1Price)
        {
            scoreManager.SubtractScore(powerUp1Price); // Subtract score
            powerUp1Price = Mathf.RoundToInt(powerUp1Price * priceMultiplier);
            UpdatePowerUpPrices();
            powerUpsController.AddPowerUp(PowerUpType.HealthBuff); // Increment HealthBuff power-up
        }
    }

    public void UpgradePowerUp2()
    {
        if (ScoreManager.GetScore() >= powerUp2Price)
        {
            scoreManager.SubtractScore(powerUp2Price); // Subtract score
            powerUp2Price = Mathf.RoundToInt(powerUp2Price * priceMultiplier);
            UpdatePowerUpPrices();
            powerUpsController.AddPowerUp(PowerUpType.DamageBuff); // Increment DamageBuff power-up
        }
    }

    public void UpgradePowerUp3()
    {
        if (ScoreManager.GetScore() >= powerUp3Price)
        {
            scoreManager.SubtractScore(powerUp3Price); // Subtract score
            powerUp3Price = Mathf.RoundToInt(powerUp3Price * priceMultiplier);
            UpdatePowerUpPrices();
            powerUpsController.AddPowerUp(PowerUpType.RangeBuff); // Increment RangeBuff power-up
        }
    }

    public void UpgradePowerUp4()
    {
        if (ScoreManager.GetScore() >= powerUp4Price)
        {
            scoreManager.SubtractScore(powerUp4Price); // Subtract score
            powerUp4Price = Mathf.RoundToInt(powerUp4Price * priceMultiplier);
            UpdatePowerUpPrices();
            powerUpsController.AddPowerUp(PowerUpType.SpeedBuff); // Increment SpeedBuff power-up
        }
    }

    private void UpdatePowerUpPrices()
    {
        powerUp1PriceText.text = "$" + powerUp1Price.ToString();
        powerUp2PriceText.text = "$" + powerUp2Price.ToString();
        powerUp3PriceText.text = "$" + powerUp3Price.ToString();
        powerUp4PriceText.text = "$" + powerUp4Price.ToString();
    }
}
