using UnityEngine;
using System.Collections;

public class CameraController : Singleton<CameraController> {

    public float movementDuration = 0.5f;


    public void SetPosition(Vector2 position)
    {
        Vector3 end = new Vector3(position.x, position.y, transform.position.z);
        StartCoroutine(movementCoroutine(transform.position, end, movementDuration));
    }

    private IEnumerator movementCoroutine(Vector3 startPosition, Vector3 endPosition, float time)
    {
        float timer = 0;
        while(timer < time)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, timer / time);
            timer += Time.deltaTime;
            yield return 0;
        }
        transform.position = endPosition;
        MapManager.Instance.endOfCameraAnim();
    }
}
