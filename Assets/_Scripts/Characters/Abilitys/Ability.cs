using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    [SerializeField] private float cooldown;
    private float currentCooldown;

    public virtual void Execute(GameObject player) { }
    public void Use(GameObject player)
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0)
        {
            Execute(player);
            currentCooldown = cooldown;
        }
    }
}
