using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // Timer controlle
    private Timer timer;
    [SerializeField]
    private float duration = 0.5f;

    private float startTime;

    // Manage creep
    [SerializeField]
    private GameObject creep;
    [SerializeField]
    private GameObject guard;

    private ScreenHelper screenHelper;

    // Start is called before the first frame update
    void Start()
    {
        // Init timer
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = duration;           
        timer.Run();
        startTime = Time.time;

        screenHelper = gameObject.AddComponent<ScreenHelper>();

        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            Instantiate<GameObject>(creep, screenHelper.RandomTargetDestination(), Quaternion.identity);
            //Instantiate<GameObject>(guard, screenHelper.RandomTargetDestination(), Quaternion.identity);
            // StartTimer again;
            timer.Run();
            startTime = Time.time;
        }
    }


}
