using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{   

    [SerializeField]
    float _speed;

    [SerializeField]
    int _damageAmount;

    Vector3 _direction;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();

        if(hit != null)
        {
            hit.Damage(_damageAmount);
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        if(direction.x > 0)
        {
            _direction = Vector3.right;
        }
        else
        {
            _direction = Vector3.left;
        }
    }
}
