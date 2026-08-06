using UnityEngine;

namespace LightRace3D.Gameplay
{
    public class TrailSpawner : MonoBehaviour
    {
        public BikeController bikeController;
        public float spawnDistance = 0.5f;

        private Vector3 lastPosition;

        private void Start()
        {
            if (bikeController == null)
                bikeController = GetComponent<BikeController>();

            lastPosition = transform.position;
        }

        private void Update()
        {
            if (Vector3.Distance(lastPosition, transform.position) >= spawnDistance)
            {
                if (GameManager.Instance != null && GameManager.Instance.IsMatchActive)
                {
                    TrailManager.Instance?.CreateTrailSegment(bikeController.playerId, transform.position, transform.rotation, bikeController.trailColor);
                    lastPosition = transform.position;
                }
            }
        }
    }
}
