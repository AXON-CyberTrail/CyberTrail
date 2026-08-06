using UnityEngine;

namespace LightRace3D.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        public static SpawnManager Instance { get; private set; }

        public Transform[] spawnPoints;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public Transform GetSpawnPoint(int index)
        {
            if (spawnPoints == null || spawnPoints.Length == 0)
                return null;

            return spawnPoints[index % spawnPoints.Length];
        }
    }
}