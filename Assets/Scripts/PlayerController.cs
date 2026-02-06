using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public InputAction moveAction;


    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        var input = moveAction.ReadValue<Vector2>();
        var inputX = input.x;

        
        
        transform.Translate(inputX * speed * Time.deltaTime * Vector3.right);
        //transform.position.x = Mathf.Clamp(transform.position.x, -10, 10);

        if (transform.position.x >= 10) 
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -10) 
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
        
        
    }
}
