using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public float buffer;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < (-Camera.main.orthographicSize - buffer) || transform.position.z > (Camera.main.orthographicSize + buffer))
        {
            Destroy(gameObject);
        }
        
    }
}
