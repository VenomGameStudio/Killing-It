using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<CoinSpawner>().coinCount += 1;
            Destroy(gameObject);
        }
    }
}
