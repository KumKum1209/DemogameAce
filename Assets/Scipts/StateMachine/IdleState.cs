using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private float timer;
    private float randomTime;

    public void OnEnter(EnemyController enemy)
    {
        enemy.StopMoving();
        timer = 0;
        randomTime = Random.Range(2f, 3f);
    }

    public void OnExecute(EnemyController enemy)
    {
        timer += Time.deltaTime;

        if (timer > randomTime)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

    public void OnExit(EnemyController enemy)
    {
       
    }

}
