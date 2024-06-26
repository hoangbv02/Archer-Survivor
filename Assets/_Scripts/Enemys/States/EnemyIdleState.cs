using System.Collections;
using System.Collections.Generic;
using Hoangbv;
using UnityEngine;

public class EnemyIdleState : State<EnemyBrain>
{
    public override void Update()
    {
        base.Update();
        if (_owner.HasPlayer())
        {
            _fsm.SwitchState<EnemyMoveState>();
        }
    }
}
