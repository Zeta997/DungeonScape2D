using UnityEngine;

public class ScriptDiamon : MonoBehaviour
{
    Rigidbody2D _velocity;

    private void Start()
    {
        _velocity= GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _velocity.velocity = Vector2.down;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
           if (other.tag == "Player")
           {

             Player _player = other.GetComponent<Player>();
             _player.Diamondcount += 1;
             Destroy(gameObject);
           }
        }
    }
}
