using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAbilitys : MonoBehaviour
{
    public List<Ability> _abilities = new List<Ability>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var ability in _abilities){
            ability.Use(gameObject);
        }
        
    }
}
