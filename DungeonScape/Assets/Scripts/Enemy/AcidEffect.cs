using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 2.0F);
    }
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable player = collision.GetComponent<IDamageable>();
        if (collision != null)
        {
            if (collision.tag == "Player")
            {
                player.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
