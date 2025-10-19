using UnityEngine;

public class TreeObjectHierarchy : MonoBehaviour
{
    [Header("Apple Settings")]
    public GameObject applePrefab;
    public float dropInterval = 2f;      // starting drop interval
    public float moveSpeed = 3f;         // starting tree speed
    public float moveRange = 5f;

    public GameObject caterpillarPrefab; // assign in Inspector
    public float caterpillarChance = 0.2f; // 20% chance an item is a caterpillar

    [Header("Difficulty Settings")]
    public float maxTreeSpeed = 6f;      // tree will not exceed this speed
    public float minDropInterval = 0.5f; // apples can drop as fast as this

    private float dropTimer = 0f;
    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move tree left/right
        transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x - startPos.x) > moveRange)
            direction *= -1;

        // Drop apples/caterpillar periodically
        dropTimer += Time.deltaTime;
        if (dropTimer >= dropInterval)
        {
            DropItem();
            dropTimer = 0f;
        }

    }

    void DropItem()
    {
        Vector3 dropPos = new Vector3(transform.position.x, transform.position.y - 1f, 0);

        if (UnityEngine.Random.value < caterpillarChance)
            Instantiate(caterpillarPrefab, dropPos, Quaternion.identity);
        else
            Instantiate(applePrefab, dropPos, Quaternion.identity);
    }


    // Call from GameManager2 to increase difficulty
    public void IncreaseDifficulty()
    {
        // Cap tree movement speed
        moveSpeed = Mathf.Min(moveSpeed * 1.1f, 10f); // tree speed will stop increasing past 10

        // Apples drop faster (but limited)
        dropInterval = Mathf.Max(0.5f, dropInterval * 0.9f);
    }

}
