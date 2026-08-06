using UnityEngine;

namespace LightRace3D.Managers
{
    public class CameraController : MonoBehaviour
    {
        public static CameraController Instance { get; private set; }
        public Transform target;
        public Vector3 offset = new Vector3(0f, 10f, -12f);
        public float followSpeed = 8f;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void LateUpdate()
        {
            if (target == null)
                return;

            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            transform.LookAt(target.position + Vector3.up * 1.5f);
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }
    }
}
