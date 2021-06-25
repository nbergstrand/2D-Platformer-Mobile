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
        animator = GetComponentInChildren<Animator>();
        target = waypoints[1].position;
    }

    public virtual void Attack()
    {

    }

    public abstract void Update();

    public abstract void Patrol();

    public abstract IEnumerator SetTarget(Vector3 position);

    public abstract void Flip();


}
