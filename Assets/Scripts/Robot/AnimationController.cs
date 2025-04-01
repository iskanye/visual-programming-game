using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Robot robot;
    [SerializeField] private Animator animator;

    void Update()
    {
        animator.SetBool("IsMoving", robot.IsMoving);
    }
}
