using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    
    public override void Attack()
    {

    }

    public override void Update()
    {
        Patrol();
    }

    public override IEnumerator SetTarget(Vector3 position)
    {
        yield return new WaitForSeconds(5f);
        
        Flip();
        target = position;
    }

    public override void Patrol()
    {
        velocity = ((transform.position - previousPosition) / Time.deltaTime);
        previousPosition = transform.position;
        
        animator.SetFloat("speed", velocity.magnitude);

        if (transform.position != target)
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        else
        {
            if (target == waypoints[0].position)
            {
                if (flipped)
                {
                    Debug.Log("Flip");
                    flipped = !flipped;
                }
                    

                StartCoroutine("SetTarget", waypoints[1].position);
            }
            else
            {
                if (!flipped)
                {
                    Debug.Log("Flip");
                    flipped = !flipped;
                }
                    

                StartCoroutine("SetTarget",waypoints[0].position);
            }

        }
    }

    public override void Flip()
    {
        if (flipped)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            
        }

    }


}
