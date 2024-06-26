using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ability", menuName = "FireRain")]
public class AbilityFireRain : Ability
{
    [SerializeField] GameObject _prefab;
    public override void Execute(GameObject player)
    {
        base.Execute(player);
        List<GameObject> enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        GameObject enemy = enemies.OrderBy(e => Vector3.Distance(e.transform.position, player.transform.position)).FirstOrDefault();
        if (enemy != null)
        {
            GameObject go = Instantiate(_prefab, player.transform.position + new Vector3(Random.RandomRange(-10f, 10f), 5f, Random.RandomRange(-10f, 10f)), Quaternion.identity);
            Vector3 dir = (enemy.transform.position - go.transform.position).normalized;
            go.GetComponent<Rigidbody>().velocity = dir * 15f;
            Destroy(go, 2f);
        }
    }
}
