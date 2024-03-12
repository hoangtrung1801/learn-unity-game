using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    [SerializeField]
    private InputActionReference movement, pointerPosition, shoot;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = movement.action.ReadValue<Vector2>();
        // Vector2 position = pointerPosition.action.ReadValue<Vector2>();

        if (movementInput != null)
        {
            controller.Move(movementInput * Time.deltaTime * playerSpeed);
        }

       // if (position != null && position != Vector2.zero) {
         //   Debug.Log(position.x + " " + position.y);
       // }
    }
}
