using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    public int amount;

    public override void Apply(GameObject target) 
    {
        target.GetComponent<Health>().health += amount;
    }
}