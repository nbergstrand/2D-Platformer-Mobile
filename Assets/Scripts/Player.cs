using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D _rigidBody;
    
    [SerializeField]
    float _jumpHeight =5.0f;

    [SerializeField]
    float _speed;

    Animator _animator;
    bool _checkGrounded;

    Transform _playerGFX;
    

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _playerGFX = GetComponentInChildren<Transform>();

        
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float move = Input.GetAxisRaw("Horizontal") * _speed;
        _rigidBody.velocity = new Vector2(move, _rigidBody.velocity.y);

        _animator.SetFloat("speed", Mathf.Abs(move));

        
        if(move != 0)
        {
            if (move < 0)
            {
                _playerGFX.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                _playerGFX.localScale = new Vector3(1f, 1f, 1f);
            }
            
        }

        if(_checkGrounded)
        {
            if(IsGrounded())
                _animator.SetBool("jump", false);
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
        
        RaycastHit2D hitInfo  = Physics2D.Raycast(transform.position, Vector2.down, 0.60f);

        if(hitInfo.collider != null && hitInfo.collider.tag == "Ground")
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
        _animator.SetBool("jump", true);
        yield return new WaitForSeconds(0.5f);
        _checkGrounded = true;

    }

}
