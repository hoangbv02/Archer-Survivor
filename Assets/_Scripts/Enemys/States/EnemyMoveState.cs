using System.Collections;
using System.Collections.Generic;
using Hoangbv;
using UnityEngine;

public class EnemyMoveState : State<EnemyBrain>
{
    public override void Update()
    {
        base.Update();
        _owner.ChasePlayer();
        if (_owner.IsAttack())
        {
            _fsm.SwitchState<EnemyAttackState>();
        }
        else if (!_owner.HasPlayer())
        {
            _fsm.SwitchState<EnemyIdleState>();
        }
    }
}
