using UnityEngine;

public class BasketPrefab : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 basketPos = transform.position;
        basketPos.x = mousePos.x;
        transform.position = basketPos;
    }

}
