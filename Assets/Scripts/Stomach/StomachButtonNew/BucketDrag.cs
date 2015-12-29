using UnityEngine;
using System.Collections;

public class BucketCrag : MonoBehaviour {

    private Vector3 screenPoint;

    void OnMouseDrag()
    {
        Vector2 objectPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = objectPosition;

    }

}
