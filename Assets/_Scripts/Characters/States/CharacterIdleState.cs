using System.Collections;
using System.Collections.Generic;
using Hoangbv;
using UnityEngine;

public class CharacterIdleState : State<CharacterBrain>
{
    public override void Enter()
    {
        base.Enter();
        _owner.PlayAnim("Idle");
    }
    public override void Update()
    {
        base.Update();
        if (_owner.IsMoving) _fsm.SwitchState<CharacterMoveState>();
        else if (_owner.IsAttack()) _fsm.SwitchState<CharacterAttackState>();

    }
}
