using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    [SerializeField]
    GameObject _projectile;

    [SerializeField]
    Transform _firePoint;
               

    public override void Update()
    {
        base.Update();

        if(Vector3.Distance(player.transform.position, transform.position) < inCombatDistance && !inCombat)
        {
            inCombat = true;
        }
    }

    public void FireProjectile()
    {
       GameObject acidBall = Instantiate(_projectile, _firePoint.position, Quaternion.identity);

        acidBall.GetComponent<Projectile>().SetDirection(player.transform.position - transform.position); 
        
    }
}
