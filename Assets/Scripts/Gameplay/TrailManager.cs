using System.Collections.Generic;
using LightRace3D.Managers;
using UnityEngine;

namespace LightRace3D.Gameplay
{
    public class TrailManager : MonoBehaviour
    {
        public static TrailManager Instance { get; private set; }

        [Header("Trail Settings")]
        public GameObject trailSegmentPrefab;
        public float segmentSpacing = 0.5f;
        public int maxTrailSegments = 120;

        private readonly Dictionary<string, Queue<TrailSegment>> activeTrails = new();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void CreateTrailSegment(string playerId, Vector3 position, Quaternion rotation, Color color)
        {
            if (!activeTrails.ContainsKey(playerId))
            {
                activeTrails[playerId] = new Queue<TrailSegment>();
            }

            var segment = TrailPool.Instance.GetSegment();
            segment.transform.position = position;
            segment.transform.rotation = rotation;
            segment.SetColor(color);

            float lifetime = GameModeManager.Instance != null ? GameModeManager.Instance.GetTrailLifetime() : Mathf.Infinity;
            float warningTime = GameModeManager.Instance != null ? GameModeManager.Instance.GetTrailDecayWarningTime() : 0f;
            segment.Initialize(lifetime, warningTime);
            segment.gameObject.SetActive(true);

            activeTrails[playerId].Enqueue(segment);

            if (activeTrails[playerId].Count > maxTrailSegments)
            {
                var oldSegment = activeTrails[playerId].Dequeue();
                TrailPool.Instance.ReturnSegment(oldSegment);
            }
        }

        public void ClearTrail(string playerId)
        {
            if (!activeTrails.ContainsKey(playerId))
                return;

            while (activeTrails[playerId].Count > 0)
            {
                var segment = activeTrails[playerId].Dequeue();
                TrailPool.Instance.ReturnSegment(segment);
            }
        }
    }
}
