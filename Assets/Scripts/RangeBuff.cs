using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/DamageBuff")]
public class RangeBuff : PowerupEffect
{
    public int amount;
    public override void Apply(GameObject target) 
    {
        target.GetComponent<PlayerAttack>().despawnDelay += amount;
    }
}