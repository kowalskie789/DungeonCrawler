using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : Character
{
    public bool InRange = false;
    public GameObject enemy;
    private void OnTriggerStay2D(Collider2D collision)
    {
        InRange = true;
        enemy = collision.gameObject;   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        InRange=false;
        enemy = null;
    }
}
