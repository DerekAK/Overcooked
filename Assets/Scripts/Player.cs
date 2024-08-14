using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 20f;
    [SerializeField] private float rotateSpeed = 3f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking;
    private void Update(){

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        //if moveDir is equal to Vector3.zero, player is not walking
        isWalking = moveDir != Vector3.zero;

        transform.position += moveDir * speed * Time.deltaTime; //make this frame rate independent
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); //this handles rotation
    }

    public bool IsWalking(){
        return isWalking;
    }
}
