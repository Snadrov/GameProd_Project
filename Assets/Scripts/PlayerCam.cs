using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float SensX; 
    public float SensY; 

    public Transform orientation; 

    float xRotation;
    float yRotation;

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked; //lock mouse and make it invisible 
        Cursor.visible = false; 
    }

    private void Update() 
    {
        //get mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX; 
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensX; 

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam and orentation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); 
    }
}
