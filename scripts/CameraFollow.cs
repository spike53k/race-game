using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smooth = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 pos = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, pos, smooth * Time.deltaTime);

        transform.LookAt(target);
    }

    public void SetTarget(GameObject car)
    {
        target = car.transform;
    }
}