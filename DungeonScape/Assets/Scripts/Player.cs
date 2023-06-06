using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    Rigidbody2D _playerRB;
    #endregion

    #region Variables
    float velocity = 3.0f;
    float impulse = 3.0F;
    bool _jumpAvaliable = false;
    #endregion
    // Update is called once per frame
    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        CollisionFloor();
    }

    void Movement()
    {
        float _movementX = Input.GetAxisRaw("Horizontal");

        _playerRB.velocity = new Vector2(_movementX*velocity, _playerRB.velocity.y);
        if (_jumpAvaliable)
        {
            _playerRB.AddForce(Vector2.up*impulse, ForceMode2D.Impulse);
        }
    }

    void CollisionFloor()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8F);

        if (hit.collider.name == "Floor") { _jumpAvaliable = true; }
        else { _jumpAvaliable = false; }
        

        
    }
}
