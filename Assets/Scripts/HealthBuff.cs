using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    private PowerUpType powerUpType = PowerUpType.HealthBuff;

    public int amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().health += amount;
    }
}