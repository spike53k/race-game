using UnityEngine;

public class CarSelector : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public Transform spawnPoint;

    private int currentCar;
    private GameObject currentCarObj;

    void Start()
    {
        Init();
    }

    void Init()
    {
        if (SaveManager.instance == null)
        {
            Debug.LogError("SaveManager НЕ НАЙДЕН!");
            return;
        }

        currentCar = SaveManager.instance.currentCar;
        ShowCar();
    }

    public void NextCar()
    {
        currentCar++;

        if (currentCar >= carPrefabs.Length)
            currentCar = 0;

        SaveManager.instance.currentCar = currentCar;
        SaveManager.instance.Save();

        ShowCar();
    }

    public void PrevCar()
    {
        currentCar--;

        if (currentCar < 0)
            currentCar = carPrefabs.Length - 1;

        SaveManager.instance.currentCar = currentCar;
        SaveManager.instance.Save();

        ShowCar();
    }

    void ShowCar()
    {
        if (carPrefabs == null || carPrefabs.Length == 0)
        {
            Debug.LogError("carPrefabs пустой!");
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogError("spawnPoint не задан!");
            return;
        }

        if (currentCarObj != null)
            Destroy(currentCarObj);

        currentCarObj = Instantiate(
            carPrefabs[currentCar],
            spawnPoint.position,
            spawnPoint.rotation
        );
    }
}