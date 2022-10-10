using UnityEngine;

public class Timer : MonoBehaviour
{
    // Timer duration
    private float totalSeconds = 0;

    // Timer execution
    private float elapsedSeconds = 0;
    bool running = false;

    // Support for Finished property
    bool started = false;

    public void Run()
    {
        // Only run with valid duration
        if (totalSeconds > 0)
        {
            running = true;
            started = true;
            elapsedSeconds = 0;
        }

    }

    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }
    }

    public bool Finished
    {
        get { return started && !running; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
            {
                running = false;
            }
        }
    }
}
