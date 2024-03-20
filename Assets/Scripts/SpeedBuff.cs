using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : PowerupEffect
{
    private PowerUpType powerUpType = PowerUpType.SpeedBuff;
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().modifiedSpeed += amount;
    }
}