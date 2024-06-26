using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Hoangbv;
using UnityEngine;

public class CharacterBrain : MonoBehaviour
{
    [SerializeField] float _distanceAttack = 5f;
    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] IAttack[] _attacks;
    [SerializeField] Animator _animator;
    private CharacterMovement _characterMovement;
    private JoystickHandler _joystickHandler;
    private Fsm<CharacterBrain> _stateMachine;
    private void Awake()
    {
        InitStateMachine();
        _characterMovement = GetComponent<CharacterMovement>();
        _joystickHandler = GetComponent<JoystickHandler>();
        _attacks = GetComponents<IAttack>();

    }
    private void InitStateMachine()
    {
        _stateMachine = new Fsm<CharacterBrain>(this);
        _stateMachine.AddState<CharacterIdleState>();
        _stateMachine.AddState<CharacterMoveState>();
        _stateMachine.AddState<CharacterAttackState>();
        _stateMachine.AddState<CharacterMoveAndAttackState>();

        _stateMachine.SwitchState<CharacterIdleState>();
    }
    void Update()
    {
        _stateMachine.Update();
        print(_stateMachine.GetCurrentState());
    }
    public bool IsAttack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, _distanceAttack, _enemyLayer);
        return hitEnemies.Length > 0;
    }
    public bool IsMoving => _joystickHandler.GetJoystickDirection.magnitude >= .1f;
    public void Walk()
    {
        _characterMovement.MoveFollowDirection(_joystickHandler.GetJoystickDirection.normalized);
    }
    public void LookRotationJoystick()
    {
        _characterMovement.LookFollowDirection(_joystickHandler.GetJoystickDirection.normalized);
    }
    public void LookRotationEnemy()
    {
        List<GameObject> enemys = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        GameObject enemyNear = enemys.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).FirstOrDefault();
        if (enemyNear != null)
        {
            Vector3 enemyDir = enemyNear.transform.position - transform.position;
            _characterMovement.LookFollowDirection(enemyDir);
        }
    }
    public void Attack()
    {
        foreach (var attack in _attacks)
        {
            attack.ExecuteAttack();
        }
    }

    public void PlayAnim(string name, int layer = 0)
    {
        _animator.CrossFade(name, .1f, layer);
    }
}
