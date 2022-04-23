using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    PlayerController controller;

    [SerializeField]
    Animator animator;

    bool lastLeft = false;
    bool lastUp = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 speed = controller.Velocity;
        Vector2 control = controller.MovementVector;

        if (control.x != 0)
        {
            lastLeft = control.x < 0;
        }
        if (control.y != 0)
        {
            lastUp = control.y > 0;
        }

        animator.SetFloat("Control_Horizontal", control.x);
        animator.SetFloat("Control_Vertical", control.y);
        animator.SetFloat("Speed_Horizontal", speed.x);
        animator.SetFloat("Speed_Vertical", speed.y);
        animator.SetFloat("Absolute_Speed_Horizontal", Mathf.Abs(speed.x));
        animator.SetFloat("Absolute_Speed_Vertical", Mathf.Abs(speed.y));
        animator.SetInteger("Horizontal_Direction", control.x == 0 ? (lastLeft ? -1 : 1) : (int)Mathf.Sign(control.x));
        animator.SetInteger("Vertical_Direction", control.y == 0 ? (lastUp ? 1 : -1) : (int)Mathf.Sign(control.y));
    }
}
