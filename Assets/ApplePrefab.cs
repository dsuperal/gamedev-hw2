using UnityEngine;

public class ApplePrefab : MonoBehaviour
{
    public float fallSpeed = 5f;      // falling speed
    public float bottomY = -5f;       // destroy if below this
    private bool isCaught = false;    // prevents multiple scoring

    void Update()
    {
        // Move the apple down
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Check if apple fell below the screen
        if (transform.position.y < bottomY && !isCaught)
        {
            isCaught = true; // prevent double counting
            GameManager2.Instance.MissApple();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only trigger once
        if (isCaught) return;

        if (other.CompareTag("Basket2")) // make sure your baskets are tagged "Basket2"
        {
            isCaught = true; // mark as caught
            GameManager2.Instance.CatchApple();
            Destroy(gameObject);
        }
    }
}
