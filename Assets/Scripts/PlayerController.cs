using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public InputAction moveAction;
    public InputAction shootAction;

    public Camera camera;

    public GameObject foodPrefab;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        var input = moveAction.ReadValue<Vector2>();
        var inputX = input.x;



        transform.Translate(inputX * speed * Time.deltaTime * Vector3.right);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -camera.orthographicSize, camera.orthographicSize), transform.position.y, transform.position.z);

        //if (transform.position.x >= 10) 
        //{
        //    transform.position = new Vector3(10, transform.position.y, transform.position.z);
        //}
        //if (transform.position.x <= -10) 
        //{
        //    transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        //}

        if (shootAction.triggered)
        {
            Instantiate(foodPrefab, transform.position, Quaternion.identity);
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawSphere(transform.position, 1);
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(transform.position,Camera.main.transform.position);
        Gizmos.DrawLine(
            new Vector3(-camera.orthographicSize, transform.position.y, transform.position.z),
            new Vector3(camera.orthographicSize, transform.position.y, transform.position.z)
            );
    }
}
