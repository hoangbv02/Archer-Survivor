using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    private NavMeshAgent _agent;
    private Vector3 _prePosition;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _prePosition = transform.position;
        _agent.speed = _speed;
    }
    public void MoveFollowDirection(Vector3 direction)
    {
        _agent.Move(direction * _agent.speed * Time.deltaTime);
    }
    public void LookFollowDirection(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion quaternion = Quaternion.LookRotation(direction);
            transform.rotation = quaternion;
        }
    }
    public void MoveToTarget(Vector3 target)
    {
        _agent.SetDestination(target);
    }
    public bool IsMoving()
    {
        bool IsMoving = false;
        if (transform.position == _prePosition)
        {
            IsMoving = false;
        }
        else
        {
            IsMoving = true;
        }
        _prePosition = transform.position;
        return IsMoving;
    }
}
