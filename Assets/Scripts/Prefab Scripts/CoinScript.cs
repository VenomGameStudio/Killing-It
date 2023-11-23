using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StaticDataManager.currentCoins += 1;
            Destroy(gameObject);
        }
    }
}
