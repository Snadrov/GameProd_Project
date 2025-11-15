using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed; 
    public Transform orientation; 

    float horizontalInput; 
    float verticalInput; 

    Vector3 moveDirection; 

    void Update()
    {
        MyInput(); 
        MovePlayer(); 
    }
    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical"); 
    }

    void MovePlayer()
    {
        //calculate movement direction 
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; 

        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);
    }
}
