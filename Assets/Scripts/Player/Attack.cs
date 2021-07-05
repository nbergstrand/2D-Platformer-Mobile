using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool canDoDamage = true;
    public bool canAttack = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        

        IDamageable hit = other.GetComponent<IDamageable>();

        if(hit != null && canDoDamage)
        {
            if (other.tag == "Enemy")
                hit.Damage(GetComponentInParent<Player>().AttackPower);
            else
                hit.Damage(GetComponentInParent<Enemy>().AttackPower);
            canDoDamage = false;
            
        }
    }

    

    
}
