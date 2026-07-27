using UnityEngine;

namespace LightRace3D.Managers
{
    public class EffectsManager : MonoBehaviour
    {
        public static EffectsManager Instance { get; private set; }

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

        public void SpawnExplosion(Vector3 position, Color color)
        {
            // Criar efeito de explosão neon para morte.
        }

        public void SpawnTrailDecayEffect(Vector3 position)
        {
            // Efeito visual de decaimento do rastro.
        }
    }
}
