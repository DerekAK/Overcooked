using System;
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

        float playerRadius = 0.7f;
        float playerHeight = 2f;
        float moveDistance = speed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
        
        if(!canMove){
            //Going into an obstacle
            //Attempt only x movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove){
                moveDir = moveDirX;
            }
            else{
                //attempt z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove){
                    moveDir = moveDirZ;
                }
            }
        }
        if (canMove){
            transform.position += moveDir * moveDistance; //make this frame rate independent
        }

        //if moveDir is equal to Vector3.zero, player is not walking
        isWalking = moveDir != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); //this handles rotation
    }

    public bool IsWalking(){
        return isWalking;
    }
}
