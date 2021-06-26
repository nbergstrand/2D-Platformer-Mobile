using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;

    [SerializeField]
    protected int speed;

    [SerializeField]
    protected int gems;

    [SerializeField]
    protected Transform[] waypoints;

    protected Vector3 target;
    protected Vector3 velocity;
    protected Vector3 previousPosition;
    protected Animator animator;

    protected bool flipped;

    

    public void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        Patrol();
    }

    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        target = waypoints[1].position;
    }


    public virtual void Attack()
    {

    }
       

    public virtual void Patrol()
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
                    flipped = !flipped;
                    StartCoroutine("SetTarget", waypoints[1].position);
                }
                
            }
            else
            {
                if (!flipped)
                {

                    flipped = !flipped;
                    StartCoroutine("SetTarget", waypoints[0].position);

                }
                
            }

        }
    }

    public virtual IEnumerator SetTarget(Vector3 position)
    {

        yield return new WaitForSeconds(5f);
        target = position;
        Flip();
    }


    public virtual void Flip()
    {
        if (flipped)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

        }

    }


}
