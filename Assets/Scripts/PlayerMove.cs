using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform camera;
    public Animator anim;
    public float speed = 3;
    public float rotationSpeed = 720;
    Quaternion rotation;
    public float cameraHeight = 2;
    public float cameraDistance = 4;
    int multiplier = 1;
    bool keyPressed = false;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && !keyPressed) {
            keyPressed = true;
            multiplier = multiplier * -1;
        }

        float horizontalInput = Input.GetAxis("Horizontal") * multiplier;
        float verticalInput = Input.GetAxis("Vertical") * multiplier;

        anim.SetFloat("vertical",verticalInput);
        anim.SetFloat("horizontal",horizontalInput);

        Vector3 movementDirection = new Vector3(-horizontalInput, 0, -verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if(movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = rotation;            
        }     

        //camera follow
        Vector3 cameraMovementDirection = new Vector3(0, 0, -(verticalInput + (multiplier * cameraDistance)));
        cameraMovementDirection.Normalize();
        camera.transform.forward = cameraMovementDirection; 
        camera.transform.position = transform.position + new Vector3(0, cameraHeight, multiplier * cameraDistance);

        if(keyPressed && !Input.GetKey(KeyCode.LeftShift))
        {
            keyPressed = false;
        }
    }
}
