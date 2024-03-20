using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : PowerupEffect
{
    public float amount;

    public void OnEnable()
    {
        powerUpType = PowerUpType.SpeedBuff;
    }

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().modifiedSpeed += amount;
    }
}