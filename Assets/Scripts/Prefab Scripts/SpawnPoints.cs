using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;

    void Start() => Instantiate(obstacle, transform.position, Quaternion.identity);
}
