using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : ScriptableObject
{
    public virtual void Enter(BaseStateMachine stateMachine) { }
    public virtual void Exit(BaseStateMachine stateMachine) { }
    public virtual void Execute(BaseStateMachine machine) { }
}