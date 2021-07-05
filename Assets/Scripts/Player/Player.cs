using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{

    Rigidbody2D _rigidBody;
    
    [SerializeField]
    float _jumpHeight =5.0f;

    [SerializeField]
    float _speed;

    Animator _playerAnimator;
    
    bool _checkGrounded;

    Transform _playerGFX;

    Animator _effectAnimator;

    Attack _attack;
        
    [SerializeField]
    LayerMask _groundMask;

    [SerializeField]
    int _attackPower;
            
    public int AttackPower
    {
        private set{}
        get{return _attackPower; }
    }

    [SerializeField]
    int _health;

    public int Health { get; set; }
      

    void Start()
    {
        Health = _health;
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponentInChildren<Animator>();
        _playerGFX = GetComponent<Transform>();
        _effectAnimator = gameObject.transform.GetChild(1).GetComponent<Animator>();
        _attack = GetComponentInChildren<Attack>();
    }

    void Update()
    {
        PlayerMovement();
        PlayerAttack();
    }

    void PlayerMovement()
    {
        float move = Input.GetAxisRaw("Horizontal") * _speed;
        _rigidBody.velocity = new Vector2(move, _rigidBody.velocity.y);

        _playerAnimator.SetFloat("speed", Mathf.Abs(move));

        
        if(move != 0)
        {
            if (move < 0)
            {
                //_playerGFX.localScale = new Vector3(-1f, 1f, 1f);
                _playerGFX.localEulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                //_playerGFX.localScale = new Vector3(1f, 1f, 1f);
                _playerGFX.localEulerAngles = new Vector3(0, 0, 0);

            }

        }

        if(_checkGrounded)
        {
            if(IsGrounded())
                _playerAnimator.SetBool("jump", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _checkGrounded = false;
            StartCoroutine(Jump());
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpHeight);
            
        }
       

        
    }

    bool IsGrounded()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.70f,  _groundMask);
        
        if (hitInfo.collider != null && hitInfo.collider.tag == "Ground")
        {

            return true;
        }
        else
        {

            return false;
        }

    }

    IEnumerator Jump()
    {
        _playerAnimator.SetBool("jump", true);
        yield return new WaitForSeconds(0.5f);
        _checkGrounded = true;

    }

    void PlayerAttack()
    {
        if(Input.GetKeyDown(KeyCode.E) && IsGrounded() && _attack.canAttack)
        {
            _playerAnimator.SetTrigger("attack");
            _effectAnimator.SetTrigger("attack");
        }
    }

    public void Damage(int damageAmount)
    {
        Debug.Log("Hit: " + this.name + " with Damage " + damageAmount);
        Health -= damageAmount;
    }

    
}
