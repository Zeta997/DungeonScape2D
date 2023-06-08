using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    Rigidbody2D _playerRB;
    Animator _playerAN;
    Animation _playerANIM;
    SpriteRenderer _playerSprite;

    #endregion

    #region Variables
    [Header("variables")]
    [SerializeField]bool _jumpAvaliable = false;
    [SerializeField] float velocity = 3.0f;
    [SerializeField] float impulse = 0.5F;
    
    #endregion
    // Update is called once per frame
    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerAN = GetComponentInChildren<Animator>();
        _playerANIM = GetComponentInChildren<Animation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        //Attack();
        Movement();
        CollisionFloor();
    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_playerANIM.IsPlaying("hit"))
                _playerAN.SetTrigger("Attack");
            
            
        }

    }

    void Movement()
    {
        float _movementX = Input.GetAxisRaw("Horizontal");
        //movemos el personaje
        _playerRB.velocity = new Vector2(_movementX*velocity, _playerRB.velocity.y);
            
        //miramos qué tecla se pulsa pra voltear el sprite hacia una dirección u otra
        if (_movementX < 0)
        {
            _playerSprite.flipX = true;
            _playerAN.SetInteger("Movement", -(int)_movementX);
        }
        else if(_movementX >0)
        {
            _playerSprite.flipX = false;
            _playerAN.SetInteger("Movement", (int)_movementX);
        }
        else
        {
            _playerAN.SetInteger("Movement", (int)_movementX);
        }
       
        //comprobamos si se puede saltar
        if (_jumpAvaliable && Input.GetKeyDown(KeyCode.Space))
        {
            
            _playerRB.velocity = new Vector2(_playerRB.velocity.x, impulse);
            _jumpAvaliable = false;
        }
        //comprobamos si puede saltar o no
        _playerAN.SetBool("Jump", _jumpAvaliable);
    }

    void CollisionFloor()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7F, 1<<6);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer == 6) { _jumpAvaliable = true; }
            else { _jumpAvaliable = false; }
        }
    }

    IEnumerator TimeToMove()
    {
        yield return new WaitForSeconds(1.0F);
    }
}
