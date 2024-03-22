using UnityEngine;
using UnityEngine.UI;

public class PowerUpNotification : MonoBehaviour
{
    public Animator animator;

    void OnEnable()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
    }
}