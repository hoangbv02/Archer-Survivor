using System.Collections;
using System.Collections.Generic;
using Hoangbv;
using UnityEngine;

public class CharacterMoveState : State<CharacterBrain>
{
    public override void Enter()
    {
        base.Enter();
        _owner.PlayAnim("Run");
    }
    public override void Update()
    {
        base.Update();
        _owner.Walk();
        _owner.LookRotationJoystick();
        if (_owner.IsAttack()) _fsm.SwitchState<CharacterMoveAndAttackState>();
        else if (!_owner.IsMoving) _fsm.SwitchState<CharacterIdleState>();

    }
}
