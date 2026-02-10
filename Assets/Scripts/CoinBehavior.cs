using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    [Header("Rotation")]
    public float rotationSpeed = 100f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate the coin
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if player collected the coin
        if (other.CompareTag("Player"))
        {
            // Add coin to player's total
            CoinManager.instance.AddCoin();

            // Destroy the coin
            Destroy(gameObject);
        }
    } 
}