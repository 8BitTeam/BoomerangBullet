using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMovingController : MonoBehaviour
{
    [SerializeField]
    private bool keyBoard = false;

    private float rotationAmount = 0;
    [SerializeField]
    private float rotationSpeed = 10;
    private float rotationSpeedMultiplier = 10;

    private float stepPerFrame;
    [SerializeField]
    private float speed = 5;
    private float stepPerFrameMultiplier = 1;

    public Vector3 direction = new Vector3(1, 0, 0);

    public GameObject head;
    private FixedJoystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        head = gameObject.transform.GetChild(0).gameObject;
        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
   
            MoveWithKeyBoard();
        
            MovingTowardByJoyStick();
        
    }

    private void RotateFollow(Vector3 movingDirection)
    {
        rotationAmount = rotationSpeed * rotationSpeedMultiplier * Time.deltaTime;
        Vector3 facingDirection = new Vector3(-movingDirection.y, movingDirection.x, 0);
        if (movingDirection != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, facingDirection), rotationAmount);
    }

    private void MovingTowardByJoyStick()
    {
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        direction = new Vector3(moveHorizontal, moveVertical, 0);

        RotateFollow(direction);
        Moving(direction);
    }

    private void Moving(Vector3 direction)
    {
        stepPerFrame = Time.deltaTime * speed * stepPerFrameMultiplier;
        gameObject.transform.position += direction * stepPerFrame;
    }

    public Vector3 GetFacingDirection()
    {
        return head.transform.position - transform.position;
    }


    private void MoveWithKeyBoard()
    {
        MoveControl();
        Rotate();
    }


    private float RotateSpeedWithKeyBoard()
    {
        //return 0 - joystick.Horizontal * rotateSpeed * rotationParam;
        return 0 - Input.GetAxis("Horizontal") * rotationSpeed * rotationSpeedMultiplier;
    }

    private void MoveControl()
    {
        Vector2 direction = Input.GetAxis("Vertical") * (head.transform.position - gameObject.transform.position);
        Move(direction);
    }

    private void Rotate()
    {
        rotationAmount = Time.deltaTime * RotateSpeedWithKeyBoard();
        gameObject.transform.RotateAround(gameObject.transform.position, new Vector3(0, 0, 1), rotationAmount);
    }

    private void Move(Vector3 direction)
    {
        stepPerFrame = Time.deltaTime * speed;
        transform.position += direction * stepPerFrame;
    }
}
