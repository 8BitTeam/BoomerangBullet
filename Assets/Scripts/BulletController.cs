using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletController : MonoBehaviour
{
    private GameObject shooter;
    private Vector2 shootPosition;

    public Vector3 flyDirection = new Vector3();

    [SerializeField]
    private float distance = 10;
    private bool isBackToShooter = false;

    private float speed = 10;
    private float stepPerFrame = 0;

    private Rigidbody2D bulletBody;

    private float rotationAmount = 0;
    [SerializeField]
    private float rotationSpeed = 1;
    private float rotationSpeedMultiplier = 10;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnFLy();
    }

    private void OnFLy()
    {
        if (!isBackToShooter)
        {
            if (CalulateDistanceWithShootBase() >= distance)
            {
                isBackToShooter = true;
                bulletBody.velocity = Vector3.zero;
            }
        }
        if (isBackToShooter)
        {
            MoveBack();
            if (transform.position == shooter.transform.position)
            {
                shooter.GetComponent<GunController>().magazine++;
                gameObject.SetActive(false);
                isBackToShooter = false;
            }
        }
    }

    private void MoveBack()
    {
        stepPerFrame = Time.deltaTime * speed;
        transform.position = Vector2.MoveTowards(transform.position, shooter.transform.position, stepPerFrame);
    }

    private float CalulateDistanceWithShootBase()
    {
        float distance = Vector2.Distance(shootPosition, gameObject.transform.position);
        return distance;
    }

    public void Shoot(Vector3 direction, GameObject shooter)
    {
        flyDirection = direction;
        this.shooter = shooter;
        shootPosition = gameObject.transform.position;

        bulletBody = GetComponent<Rigidbody2D>();

        bulletBody.AddForce(new Vector2(flyDirection.x, flyDirection.y) * 50 * 100, ForceMode2D.Force);
       
    }

    private void RotateFollow(Vector3 movingDirection)
    {
        rotationAmount = rotationSpeed * rotationSpeedMultiplier * Time.deltaTime;
        Vector3 facingDirection = new Vector3(-movingDirection.y, movingDirection.x, 0);
        if (movingDirection != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, facingDirection), rotationAmount);
    }

}
