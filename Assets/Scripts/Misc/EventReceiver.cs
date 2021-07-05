using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiver : MonoBehaviour
{
    public void ToggleDamage()
    {
        GetComponentInChildren<Attack>().canDoDamage = true;
    }

    public void DisableAttack()
    {
        GetComponentInChildren<Attack>().canAttack = false;

    }

    public void EnableAttack()
    {
        GetComponentInChildren<Attack>().canAttack = true;

    }

    public void FireProjectile()
    {
        GetComponentInParent<Spider>().FireProjectile();

    }

    public void DropLoot()
    {
        GetComponentInParent<Enemy>().DropLoot();
    }
}
