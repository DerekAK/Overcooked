using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 20f;
    [SerializeField] private float rotateSpeed = 3f;
    private void Update(){

        Vector2 inputVector = Vector2.zero; //make sure this is inside Update function otherwise object will never stop moving

        if (Input.GetKey(KeyCode.W)){
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S)){
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A)){
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D)){
            inputVector.x = +1;
        }
        inputVector = inputVector.normalized;

        //Debug.Log((inputVector.x, inputVector.y));

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * speed * Time.deltaTime; //make this frame rate independent
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); //this handles rotation
    }
}
