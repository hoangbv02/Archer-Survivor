using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOneDirection : MonoBehaviour, IAttack
{
    [SerializeField] float _durationSpawn = 2f, _speed = 10f;
    [SerializeField][Range(0, 360)] int _angleFire = 45;
    [SerializeField] int _amountDirFire = 1;
    [SerializeField] GameObject _projectilePrefab;
    float _timerSpawn;
    public void ExecuteAttack()
    {
        CharacterBrain characterBrain = GetComponent<CharacterBrain>();
        if (characterBrain != null)
        {
            characterBrain.PlayAnim("Shot", 1);
        }
    }
    public void SpawnArrow()
    {
        for (int i = 0; i < _amountDirFire; i++)
        {
            GameObject projectile = Instantiate(_projectilePrefab, transform.position, _projectilePrefab.transform.rotation);
            Vector3 dir = Quaternion.Euler(0, (_angleFire / _amountDirFire) * i, 0) * transform.forward;
            projectile.GetComponent<Rigidbody>().velocity = dir.normalized * _speed;
            Destroy(projectile, 2f);
        }
    }
}
