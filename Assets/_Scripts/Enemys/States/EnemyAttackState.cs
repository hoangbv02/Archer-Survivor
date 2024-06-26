using System.Collections;
using System.Collections.Generic;
using Hoangbv;
using UnityEngine;

public class EnemyAttackState : State<EnemyBrain>
{
    public override void Update()
    {
        base.Update();
        _owner.Attack();
        if (!_owner.IsAttack())
        {
            _fsm.SwitchState<EnemyIdleState>();
        }
    }
}