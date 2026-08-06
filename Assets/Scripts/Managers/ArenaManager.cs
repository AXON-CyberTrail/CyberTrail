using UnityEngine;

namespace LightRace3D.Managers
{
    public class ArenaManager : MonoBehaviour
    {
        public static ArenaManager Instance { get; private set; }

        [Header("Arena Settings")]
        public float arenaRadius = 280f;
        public float arenaHeight = 1f;
        public Color boundaryColor = Color.cyan;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public bool IsInsideArena(Vector3 position)
        {
            return position.sqrMagnitude <= arenaRadius * arenaRadius;
        }

        public Vector3 GetRandomSpawnPosition()
        {
            var angle = Random.Range(0f, Mathf.PI * 2f);
            var radius = Random.Range(0f, arenaRadius * 0.9f);
            return new Vector3(Mathf.Cos(angle) * radius, 0f, Mathf.Sin(angle) * radius);
        }
    }
}
