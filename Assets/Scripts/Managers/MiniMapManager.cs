using UnityEngine;

namespace LightRace3D.Managers
{
    public class MiniMapManager : MonoBehaviour
    {
        public static MiniMapManager Instance { get; private set; }

        public Camera miniMapCamera;
        public Transform playerIndicatorPrefab;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void UpdateMap()
        {
            // Atualizar a câmera e os indicadores no minimapa.
        }
    }
}