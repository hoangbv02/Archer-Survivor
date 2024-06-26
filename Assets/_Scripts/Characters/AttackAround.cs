using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAround : MonoBehaviour, IAttack
{
    [SerializeField] float _speed = 5f;
    [SerializeField] GameObject _prefab;
    [SerializeField] GameObject obj;
    public void ExecuteAttack()
    {
    }

    // // Start is called before the first frame update
    // void Start()
    // {
    //     obj = Instantiate(_prefab, transform);

    // }

    // Update is called once per frame
    void Update()
    {
        obj.transform.RotateAround(transform.position, transform.up, _speed * Time.deltaTime);

    }
}
