using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MyBaseBehaviour,IPlayerMove
{
    [SerializeField] float MoveSpeed;
    [SerializeField] float RotateSpeed;
    [Range(0, 1)]
    [SerializeField] float RotateSmhoot;

    void Update()
    {
        GetMoveController();
    }

    public void GetMoveController()
    {
        float HorizontalMove = e_joystick.Horizontal;
        float VerticalMove = e_joystick.Vertical;

        if (e_joystick.Horizontal != 0 || e_joystick.Vertical != 0)
        {
            Vector3 movePos = new Vector3(HorizontalMove, 0, VerticalMove);
            e_rigidbody.AddForce(movePos * MoveSpeed * Time.deltaTime);

            Vector3 _direction = (Vector3.forward * VerticalMove) + (Vector3.right* HorizontalMove);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction), RotateSmhoot);

            if ((e_joystick.Horizontal != 0 || e_joystick.Vertical != 0) && e_playerStack.IsAnim == false)
                transform.PlayAnim((int)PlayerState.RUNNING);

            else
            {
                transform.PlayAnim((int)PlayerState.BOXRUNNING);
            }
        }

        else 
        {
            e_rigidbody.velocity = Vector3.zero;

            if ((e_joystick.Horizontal == 0 || e_joystick.Vertical == 0) && e_playerStack.IsAnim == false)
                transform.PlayAnim((int)PlayerState.IDLE);

            else
            {
                transform.PlayAnim((int)PlayerState.BOXIDLE);

            }
        }
    }
}
public enum PlayerState
{
    IDLE,
    RUNNING,
    BOXRUNNING,
    BOXIDLE
}
