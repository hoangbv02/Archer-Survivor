using System.Collections;
using System.Collections.Generic;
using Hoangbv;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] float _distanceAttack = 5f;
    private CharacterMovement _characterMovement;
    private Fsm<EnemyBrain> _stateMachine;
    private GameObject player;
    private void Awake()
    {
        InitStateMachine();
        _characterMovement = GetComponent<CharacterMovement>();
    }
    private void InitStateMachine()
    {
        _stateMachine = new Fsm<EnemyBrain>(this);
        _stateMachine.AddState<EnemyIdleState>();
        _stateMachine.AddState<EnemyMoveState>();
        _stateMachine.AddState<EnemyAttackState>();

        _stateMachine.SwitchState<EnemyIdleState>();
    }
    void Update()
    {
        _stateMachine.Update();
    }
    public bool IsAttack()
    {
        return Vector3.Distance(transform.position, player.transform.position) < _distanceAttack;
    }
    public bool HasPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        return player != null;
    }
    public void ChasePlayer()
    {
        _characterMovement.MoveToTarget(player.transform.position);
    }
    public void Attack(){
        print("enemy attack");
    }
}
