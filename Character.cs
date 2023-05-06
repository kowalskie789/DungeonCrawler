using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Health { get; private set; }
    public void ApplyDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            //DIE!!!
            Destroy(gameObject);
        }
    }
    public void SetHealth(int x)
    {
        Health = x;
    }


}
