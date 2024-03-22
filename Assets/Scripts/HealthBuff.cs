using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    public int amount;

    public void OnEnable()
    {
        powerUpType = PowerUpType.HealthBuff;
    }

    public override void Apply(GameObject target)
    {
        PlayerController.healthBuffMultiplier += amount;
        target.GetComponent<PlayerController>().timeBeforeHealingStarts =  5 / PlayerController.healthBuffMultiplier;
    }
}