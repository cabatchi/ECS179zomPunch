using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private static int money = 0;
    public GameObject moneyText;

    public void Update()
    {
        moneyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Money: $" + money.ToString("D4");
    }

    public static int GetMoney()
    {
        return money;
    }

    public void AddMoney(int value)
    {
        money += value;
    }

    public void SubtractMoney(int value)
    {
        money -= value;
    }

    public void ResetMoney()
    {
        money = 0;
    }
}