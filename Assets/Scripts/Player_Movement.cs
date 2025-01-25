using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private CharacterController playerController;
    public float playerSpeed = 10f;

    public float sensitivityMouse = 10f;
    public Transform playerBody;
    public Transform cameraBody;
    float xRotation = 0f;
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        LockCursor();
    }
    void Update()
    {
        PlayerMove();
        PlayerRotate();
    }
    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        playerController.Move(move * playerSpeed * Time.deltaTime);
    }
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void PlayerRotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivityMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityMouse;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // vertical rotation
        cameraBody.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // horizontal rotation 
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
