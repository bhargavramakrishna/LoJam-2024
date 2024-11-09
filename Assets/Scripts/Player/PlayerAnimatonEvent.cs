using UnityEngine;

public class PlayerAnimatonEvent : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void endTransformation()
    {
        animator.SetBool("isTransforming", false);
    }
}
