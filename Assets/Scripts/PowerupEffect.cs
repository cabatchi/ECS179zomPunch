using UnityEngine;

public abstract class PowerupEffect : ScriptableObject
{
    private PowerUpType powerUpType;
    public abstract void Apply(GameObject target);

    public PowerUpType GetPowerUpType()
    {
        return powerUpType;
    }
}