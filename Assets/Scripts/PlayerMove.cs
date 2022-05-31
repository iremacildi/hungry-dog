using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public float rotationSpeed;

    void Start()
    {

    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        anim.SetFloat("vertical",verticalInput);
        anim.SetFloat("horizontal",horizontalInput);

        Vector3 movementDirection = new Vector3(-horizontalInput, 0, -verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if(movementDirection != Vector3.zero)
        {
            //transform.forward = movementDirection;
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
