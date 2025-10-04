using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    /* Note:
      Public variables can be set in the Unity Editor.
      Private variables cannot be set in the Unity Editor.
    */

    public float speed = 20;
    public float turnSpeed = 10;
    public float horizontalInput;
    public float forwardInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //move the vehicle forward
        /* transform.Translate(Vector3.forward * Time.deltaTime * 20); */
        /* transform.Translate(Vector3.forward * Time.deltaTime * speed); */
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * horizontalInput * turnSpeed);
    }
}
