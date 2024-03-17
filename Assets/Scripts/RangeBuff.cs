using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/RangeBuff")]
public class RangeBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target) 
    {
        PlayerAttack playerAttack = target.GetComponentInChildren<PlayerAttack>();
        if (playerAttack != null)
        {
            playerAttack.despawnDelay += amount;
        }
        else
        {
            Debug.LogWarning("PlayerAttack component not found in the hierarchy of the target object.");
        }
    }
}
