using System.Collections.Generic;
using UnityEngine;

namespace LightRace3D.Gameplay
{
    public class TrailPool : MonoBehaviour
    {
        public static TrailPool Instance { get; private set; }

        public TrailSegment segmentPrefab;
        public int initialPoolSize = 200;

        private Queue<TrailSegment> pool = new();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < initialPoolSize; i++)
            {
                var clone = Instantiate(segmentPrefab, transform);
                clone.gameObject.SetActive(false);
                pool.Enqueue(clone);
            }
        }

        public TrailSegment GetSegment()
        {
            if (pool.Count == 0)
            {
                var additional = Instantiate(segmentPrefab, transform);
                additional.gameObject.SetActive(false);
                pool.Enqueue(additional);
            }

            var segment = pool.Dequeue();
            return segment;
        }

        public void ReturnSegment(TrailSegment segment)
        {
            segment.ResetSegment();
            pool.Enqueue(segment);
        }
    }
}
