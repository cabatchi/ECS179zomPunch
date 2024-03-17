using UnityEngine;

public class Powerup : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public float activeTime;

    public virtual void Activate() 
    {

    }
}