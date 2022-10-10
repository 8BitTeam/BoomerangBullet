using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovingController : MonoBehaviour
{
    // Moving controll
    protected float stepPerFrame;
    [SerializeField]
    protected float velocity = 1;

    protected Vector2 currentDestination;
    protected ScreenHelper screenHelper;

    // Controll Default setting
    protected Vector2 defaultBodySize;

    // Start is called before the first frame update
    void Start()
    {     
        screenHelper = new ScreenHelper();
        currentDestination = screenHelper.RandomTargetDestination();
        defaultBodySize = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDestination.Equals(transform.position))
        {
            currentDestination = screenHelper.RandomTargetDestination();
        }
        stepPerFrame = Time.deltaTime * velocity;
        transform.position = Vector2.MoveTowards(transform.position, currentDestination, stepPerFrame);

    }
}
