using UnityEngine;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private StomeSpawner spawner;
        void Update()
        {
            if (Input.GetKey(KeyCode.S))
            {
                spawner.Spawn();
            }
        }
    }
}
