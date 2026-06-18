using UnityEngine;

public class CarModel : MonoBehaviour
{
    public GameObject[] cars;

    void Start()
    {
        Invoke(nameof(SpawnCar), 0.05f);
    }

    void SpawnCar()
    {
        if (SaveManager.instance == null) return;
        int index = SaveManager.instance.currentCar;

        GameObject car = Instantiate(cars[index], transform.position, transform.rotation);
        
        Speedometer speedo = FindObjectOfType<Speedometer>();
        if (speedo != null) speedo.SetCar(car);

        Camera cam = Camera.main;
        if (cam != null) {
            CameraFollow follow = cam.GetComponent<CameraFollow>();
            if (follow != null) follow.SetTarget(car);
        }
    }
}