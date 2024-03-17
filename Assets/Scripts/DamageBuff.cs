using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/DamageBuff")]
public class DamageBuff : PowerupEffect
{
    public int amount;
    public override void Apply(GameObject target) 
    {
        target.GetComponent<PlayerController>().damage += amount;
    }
}