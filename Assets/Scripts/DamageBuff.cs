using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/DamageBuff")]
public class DamageBuff : PowerupEffect
{
    private PowerUpType powerUpType = PowerUpType.DamageBuff;
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().damage += amount;
    }
}