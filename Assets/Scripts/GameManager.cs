using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GameManager : MonoBehaviour
{
    [SerializeField] AssetReferenceGameObject[] allCars;

    private void Start()
    {
        LoadCar(0);
    }

    void LoadCar(int index)
    {
        allCars[index].LoadAssetAsync().Completed += OnCarLoad;
    }

    void OnCarLoad(AsyncOperationHandle<GameObject> handle)
    {
        if(handle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(handle.Result);
        }
    }
}
