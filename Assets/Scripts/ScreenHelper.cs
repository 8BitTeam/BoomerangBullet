using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHelper : MonoBehaviour
{
    private Vector2 maxSize = new Vector2(1, 3);
    private Vector2 minSize = new Vector2(1, 3);

    public Vector2 RandomTargetDestination()
    {
        Bounds boundOfCameraView = OrthographicBounds(Camera.main);
        float x = Random.Range(boundOfCameraView.min.x, boundOfCameraView.max.x);
        float y = Random.Range(boundOfCameraView.min.y, boundOfCameraView.max.y);
        return new Vector2(x, y);
    }

     public Bounds OrthographicBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }

    public Vector2 RandomsSize()
    {
        float x= Random.Range(minSize.x, maxSize.x);
        float y= Random.Range(minSize.y, maxSize.y);
        return new Vector2(x, y);
    }
}
