using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Text speedText;
    Rigidbody rb;

    public void SetCar(GameObject car)
    {
        rb = car.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb == null) return;

        float speed = rb.linearVelocity.magnitude * 3.6f;
        speedText.text = ((int)speed) + " km/h";
    }
}