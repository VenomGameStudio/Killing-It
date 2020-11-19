using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            FindObjectOfType<AudioManager>().Play("Chicken");
            FindObjectOfType<Weapon>().highScore += 1;
            Destroy(gameObject);
        }
        if (collision.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
