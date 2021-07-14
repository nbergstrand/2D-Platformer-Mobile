using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    bool isDead = false;

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
        if(!isDead)
        {
            PlayerMovement();
            PlayerAttack();
        }
        
    }

    void PlayerMovement()
    {
        
        Vector2 move = Gamepad.current.leftStick.ReadValue();

        if (Keyboard.current.aKey.isPressed)
            move = new Vector2(-1f, _rigidBody.velocity.y);

        if (Keyboard.current.dKey.isPressed)
            move = new Vector2(1f, _rigidBody.velocity.y);
        
        _rigidBody.velocity = new Vector2(move.x * _speed, _rigidBody.velocity.y);
       
        _playerAnimator.SetFloat("speed", Mathf.Abs(move.x));

        
        if(move.x != 0)
        {
            if (move.x < 0)
            {
                _playerGFX.localEulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                _playerGFX.localEulerAngles = new Vector3(0, 0, 0);

            }

        }

        if(_checkGrounded)
        {
            if(IsGrounded())
                _playerAnimator.SetBool("jump", false);
        }

        if ((Gamepad.current.aButton.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame ) && IsGrounded())
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
        if((Gamepad.current.bButton.wasPressedThisFrame || Keyboard.current.eKey.wasPressedThisFrame) && IsGrounded() && _attack.canAttack)
        {
            _playerAnimator.SetTrigger("attack");
            _effectAnimator.SetTrigger("attack");
        }
    }

    public void Damage(int damageAmount)
    {
        Debug.Log("Hit: " + this.name + " with Damage " + damageAmount);
        Health -= damageAmount;

        UIManager.Instance.UpdateHealthUI(Health);

        if(Health <= 0 && !isDead)
        {
            isDead = true;
            _playerAnimator.SetTrigger("death");

        }

    }


    
}
