using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemShop : MonoBehaviour
{
    [SerializeField] public GameObject shopDisplay;
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
    //private ScoreManager scoreManager;
    private MoneyManager moneyManager;
    private PlayerPowerUpsController powerUpsController;

    void Start()
    {
        shopDisplay.SetActive(false);
        moneyManager = FindObjectOfType<MoneyManager>(); // Find and store reference to ScoreManager
        powerUpsController = FindObjectOfType<PlayerPowerUpsController>(); // Find and store reference to PlayerPowerUpsController
        UpdatePowerUpPrices();
        powerUp1Button.onClick.AddListener(UpgradePowerUp1);
        powerUp2Button.onClick.AddListener(UpgradePowerUp2);
        powerUp3Button.onClick.AddListener(UpgradePowerUp3);
        powerUp4Button.onClick.AddListener(UpgradePowerUp4);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Toggle the canvas visibility
            shopDisplay.SetActive(!shopDisplay.activeSelf);
        }
        if (!ZombieSpawner.waveIsDone)
        {
            // Close the item shop if the wave is no longer done
            shopDisplay.SetActive(false);
        }
        else
        {
            shopDisplay.SetActive(true);
        }
    }
    // void OnWaveDone()
    // {
    //     // Enable the canvas when the wave is done
    //     canvas.SetActive() = true;
    // }

    public void UpgradePowerUp1()
    {
        if (MoneyManager.GetMoney() >= powerUp1Price)
        {
            moneyManager.SubtractMoney(powerUp1Price); // Subtract money
            powerUp1Price = Mathf.RoundToInt(powerUp1Price * priceMultiplier);
            UpdatePowerUpPrices();
            powerUpsController.AddPowerUp(PowerUpType.HealthBuff); // Increment HealthBuff power-up display

            HealthBuff healthBuff = ScriptableObject.CreateInstance<HealthBuff>();
            healthBuff.amount = 1; 

            healthBuff.Apply(GameObject.FindGameObjectWithTag("Player"));
            
        }
    }

    public void UpgradePowerUp2()
    {
        if (MoneyManager.GetMoney() >= powerUp2Price)
        {
            moneyManager.SubtractMoney(powerUp2Price); // Subtract money
            powerUp2Price = Mathf.RoundToInt(powerUp2Price * priceMultiplier);
            UpdatePowerUpPrices();
            powerUpsController.AddPowerUp(PowerUpType.DamageBuff); // Increment DamageBuff power-up

            DamageBuff damageBuff = ScriptableObject.CreateInstance<DamageBuff>();
            damageBuff.amount = 1; 

            damageBuff.Apply(GameObject.FindGameObjectWithTag("Player"));

        }
    }

    public void UpgradePowerUp3()
    {
        if (MoneyManager.GetMoney() >= powerUp3Price)
        {
            moneyManager.SubtractMoney(powerUp3Price); // Subtract money
            powerUp3Price = Mathf.RoundToInt(powerUp3Price * priceMultiplier);
            UpdatePowerUpPrices();
            powerUpsController.AddPowerUp(PowerUpType.RangeBuff); // Increment RangeBuff power-up

            RangeBuff rangeBuff = ScriptableObject.CreateInstance<RangeBuff>();
            rangeBuff.amount = 0.2f; // Set the amount (adjust as needed)

            rangeBuff.Apply(GameObject.FindGameObjectWithTag("Player"));
        }
    }

    public void UpgradePowerUp4()
    {
        if (MoneyManager.GetMoney() >= powerUp4Price)
        {
            moneyManager.SubtractMoney(powerUp4Price); // Subtract money
            powerUp4Price = Mathf.RoundToInt(powerUp4Price * priceMultiplier);
            UpdatePowerUpPrices();
            powerUpsController.AddPowerUp(PowerUpType.SpeedBuff); // Increment SpeedBuff power-up
            
            SpeedBuff speedBuff = ScriptableObject.CreateInstance<SpeedBuff>();
            speedBuff.amount = 0.2f; // Set the amount (adjust as needed)

            speedBuff.Apply(GameObject.FindGameObjectWithTag("Player"));
        }
    }

    private void UpdatePowerUpPrices()
    {
        powerUp1PriceText.text = powerUp1Price.ToString();
        powerUp2PriceText.text = powerUp2Price.ToString();
        powerUp3PriceText.text = powerUp3Price.ToString();
        powerUp4PriceText.text = powerUp4Price.ToString();
    }
}
