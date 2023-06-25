using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    #region Components
    [Header("Componentes")]
    [SerializeField] Transform _playerSprite;
    Rigidbody2D _playerRB;
    Animator _playerAN, _swordAttack;
    SpriteRenderer _swordAttackSprite;
    #endregion

    #region Variables
    [Header("variables")]
    [SerializeField] bool _jumpAvaliable = false;
    [SerializeField] float velocity = 3.0f;
    [SerializeField] float impulse = 0.5F;
    public int Diamondcount = 0;
    public int Health { get; set; }
    #endregion

    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerAN = GetComponentInChildren<Animator>();
        _swordAttack = transform.GetChild(1).GetComponent<Animator>();
        _swordAttackSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CollisionFloor();
        Attack();
        Movement();
    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && _jumpAvaliable)
        {
            _playerAN.SetTrigger("Attack");
            //_swordAttack.SetTrigger("EffectAttack");
        }
    }

    void Movement()
    {
        float _movementX = Input.GetAxisRaw("Horizontal");

        _playerRB.velocity = new Vector2(_movementX * velocity, _playerRB.velocity.y);

        if (_movementX < 0)
        {
            _playerSprite.transform.rotation = Quaternion.Euler(0, 180.0F, 0);
            _swordAttackSprite.flipX = true;
            _playerAN.SetInteger("Movement", -(int)_movementX);
        }
        else if (_movementX > 0)
        {
            _playerSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
            _swordAttackSprite.flipX = false;
            _playerAN.SetInteger("Movement", (int)_movementX);
        }
        else
        {
            _playerAN.SetInteger("Movement", (int)_movementX);
        }

        if (_jumpAvaliable && Input.GetKeyDown(KeyCode.Space))
        {

            _playerRB.velocity = new Vector2(_playerRB.velocity.x, impulse);
            _jumpAvaliable = false;
        }
        _playerAN.SetBool("Jump", _jumpAvaliable);

    }

    void CollisionFloor()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7F, 1 << 6);
        Debug.DrawRay(transform.position, Vector2.down * 0.7F, Color.green);
        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.name);
            if (hit.collider.gameObject.layer == 6) { _jumpAvaliable = true; }

        }
        else
        {
            _jumpAvaliable = false;
        }
    }

    public void Damage()
    {
        //damage to player
    }

}
