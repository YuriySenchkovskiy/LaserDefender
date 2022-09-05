using UnityEngine;

namespace Utils
{
    public class SpawnUtils : MonoBehaviour
    {
        public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            return Instantiate(prefab, position, rotation);
        }

        public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, GameObject container)
        {
            return Instantiate(prefab, position, rotation, container.transform);
        }
    }
}