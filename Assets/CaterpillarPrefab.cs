using UnityEngine;

public class CaterpillarPrefab : MonoBehaviour
{
    public float fallSpeed = 2f;      // Falling speed
    public float bottomY = -5f;       // Destroy if it reaches bottom

    private bool hasTriggered = false;

    void Update()
    {
        // Move downward
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Destroy if it goes below the screen
        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;
        if (other.CompareTag("Basket2"))
        {
            hasTriggered = true;
            GameManager2.Instance.GameOver();
            Destroy(gameObject);
        }
    }
}
