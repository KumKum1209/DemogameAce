using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.TextCore.Text;

public class EnemyController : CharacterController
{
    [SerializeField] private float attackrange;
    [SerializeField] private float movespeed;
    [SerializeField] private GameObject Attackarea;
    [SerializeField] Rigidbody2D rb;

    private IState currenState;

    private bool IsRight = true;
    private CharacterController target;
    public CharacterController Target => target;

    void Update()
    {
        if (currenState != null)
        {
            currenState.OnExecute(this);
        }
    }
    public void ChangeState(IState newstate)
    {
        if (currenState != null)
        {
            currenState.OnExit(this);
        }
        currenState = newstate;
        if (currenState != null)
        {
            currenState.OnEnter(this);
        }

    }
    internal void SetTarget(CharacterController character)
    {
        this.target = character;
        if (IsTargetInRange())
        {
            ChangeState(new AttackState());
        }
        else
            if (Target != null)
        {
            ChangeState(new PatrolState());
        }
        else
        {
            ChangeState(new IdleState());
        }
    }
    public bool IsTargetInRange()
    {
        if (Target != null && Vector2.Distance(target.transform.position, transform.position) <= attackrange)
        {
            return true;
        }
        else
            return false;
    }
    public void StopMoving()
    {
        ChangeAnim("Idle");
        rb.velocity = Vector2.zero;
    }
    public void Moving()
    {
        ChangeAnim("Run");
        rb.velocity = transform.right * movespeed ;
    }
    public void ChangeDirection(bool isright)
    {
        this.IsRight = isright;
        transform.rotation = IsRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
    }
}
