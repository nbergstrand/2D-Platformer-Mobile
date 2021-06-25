using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public override void Patrol()
    {
    }

    public override IEnumerator SetTarget(Vector3 position)
    {
        yield return new WaitForSeconds(2f);
    }

    public override void Update()
    {

    }
    public override void Flip()
    {
        if (flipped)
            transform.localScale = new Vector3(-1f, -1f, -1f);
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

        }

    }
}
