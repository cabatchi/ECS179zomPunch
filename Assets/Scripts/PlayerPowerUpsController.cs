using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpsController : MonoBehaviour
{
    private Dictionary<PowerUpType, int> powerUpCounts = new Dictionary<PowerUpType, int>
    {
        { PowerUpType.HealthBuff, 0 },
        { PowerUpType.DamageBuff, 0 },
        { PowerUpType.RangeBuff, 0 },
        { PowerUpType.SpeedBuff, 0 }
    };

    public void AddPowerUp(PowerUpType powerUpType)
    {
        powerUpCounts[powerUpType]++;
    }

    public int GetPowerUpCount(PowerUpType powerUpType)
    {
        return powerUpCounts[powerUpType];
    }
}

public enum PowerUpType
{
    HealthBuff,
    DamageBuff,
    RangeBuff,
    SpeedBuff
}