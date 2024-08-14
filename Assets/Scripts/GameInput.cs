using UnityEngine;

public class GameInput : MonoBehaviour
{
    // Start is called before the first frame update

    private PlayerInputActions playerInputActions;

    private void Awake(){
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized(){
        //Vector2 inputVector = Vector2.zero; //make sure this is inside Update function otherwise object will never stop moving

        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>(); //this is using new input system


        // if (Input.GetKey(KeyCode.W)){
        //     inputVector.y = 1;
        // }
        // if (Input.GetKey(KeyCode.S)){
        //     inputVector.y = -1;
        // }
        // if (Input.GetKey(KeyCode.A)){
        //     inputVector.x = -1;
        // }
        // if (Input.GetKey(KeyCode.D)){
        //     inputVector.x = 1;
        // }
        return inputVector.normalized;
    }
}
