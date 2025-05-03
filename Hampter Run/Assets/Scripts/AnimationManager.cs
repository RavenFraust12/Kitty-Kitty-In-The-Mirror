using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Idle()
    {
        animator.SetInteger("AnimState", 0);
    }

    public void Move()
    {
        animator.SetInteger("AnimState", 1);
    }

    public void Jumping()
    {
        animator.SetInteger("AnimState", 2);
    }

    public void Falling()
    {
        animator.SetInteger("AnimState", 3);
    }

    public void Pushing()
    {
        animator.SetTrigger("Push");
    }


}
