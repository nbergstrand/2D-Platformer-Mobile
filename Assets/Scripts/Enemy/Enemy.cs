using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected float speed;

    protected Vector3 target;
    protected Vector3 velocity;
    protected Vector3 previousPosition;
    protected Animator animator;
    protected bool flipped;

    [SerializeField]
    protected Transform[] waypoints;

    [SerializeField]
    protected int health;
    
    public int Health { get; set; }
            
    [SerializeField]
    protected bool isHit = false;
    [SerializeField]
    protected bool inCombat = false;

    [SerializeField]
    protected float inCombatDistance = 6;
    
    protected Player player;

    protected bool isDead;

    [SerializeField]
    bool _patrolling;

    [SerializeField]
    protected int attackPower;

    public int AttackPower
    {
        private set { }
        get { return attackPower; }
    }

    [SerializeField]
    float attackCooldown = 2f;

    float _attackTimer;

    [SerializeField]
    int _gems;

    [SerializeField]
    GameObject _loot;

    [SerializeField]
    Transform _lootPosition;

    public void Start()
    {
        Init();
    }

   
    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        target = waypoints[1].position;
        Health = health;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Update()
    {
        if (!isDead)
            Movement();
    }

    public virtual void Movement()
    {
        if (inCombat)
        {            
            FaceTowards(player.transform.position - transform.position);
            _attackTimer -= Time.deltaTime;

            if (_attackTimer <= 0)
            {
                Attack();
                _attackTimer = attackCooldown;
            }
        }

        if (inCombat && Vector3.Distance(transform.position, player.transform.position) > inCombatDistance)
        {
            isHit = false;
            inCombat = false;
            FaceTowards(target - transform.position);
        }
        
      

        velocity = ((transform.position - previousPosition) / Time.deltaTime);
        previousPosition = transform.position;

        animator.SetFloat("speed", velocity.magnitude);

        if(_patrolling)
        {
            if (!isHit || !inCombat)
            {
                if (transform.position != target)
                {

                    transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                }
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
        }

       
        
    }

    public virtual IEnumerator SetTarget(Vector3 position)
    {

        yield return new WaitForSeconds(5f);
        target = position;
        FaceTowards(position - transform.position);
    }


    public virtual void FaceTowards(Vector3 direction)
    {
        
        if (direction.x < 0f)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

        }

        
    }


    public virtual void Attack()
    {
        animator.SetTrigger("attack");
    }

    public virtual void Damage(int damageAmount)
    {

        if (isDead)
            return;
        
        Health -= damageAmount;


        animator.SetTrigger("hit");

        isHit = true;
        inCombat = true;


        if (Health <= 0)
        {
            isDead = true;
            animator.SetTrigger("death");
            Destroy(gameObject, 5f);
        }
    }

    public virtual void DropLoot()
    {
        var loot = Instantiate(_loot, _lootPosition.position, Quaternion.identity);

        loot.GetComponent<Diamonds>().SetAmount(_gems);
    }

}
