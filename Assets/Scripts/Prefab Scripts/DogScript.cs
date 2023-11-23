using UnityEngine;

public class DogScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.DecreaseHealth();
            Destroy(gameObject);
        }
    }
}
