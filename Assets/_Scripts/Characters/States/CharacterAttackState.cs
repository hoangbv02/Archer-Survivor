using System.Collections;
using System.Collections.Generic;
using Hoangbv;
using UnityEngine;

public class CharacterAttackState : State<CharacterBrain>
{
    public override void Enter()
    {
        base.Enter();
        _owner.Attack();
    }
    public override void Update()
    {
        base.Update();
        if (!_owner.IsAttack()) _fsm.SwitchState<CharacterIdleState>();
        else if (_owner.IsMoving) _fsm.SwitchState<CharacterMoveState>();
    }
}
