using System.Collections;
using System.Collections.Generic;
using Hoangbv;
using UnityEngine;

public class CharacterMoveAndAttackState : State<CharacterBrain>
{
    public override void Enter()
    {
        base.Enter();
        _owner.PlayAnim("Run");
        _owner.Attack();
    }
    public override void Update()
    {
        base.Update();
        _owner.Walk();
        _owner.LookRotationEnemy();
        if (!_owner.IsMoving || !_owner.IsAttack()) _fsm.SwitchState<CharacterIdleState>();
    }
    public override void Exit()
    {
        base.Exit();
        _owner.PlayAnim("New State", 1);
    }
}