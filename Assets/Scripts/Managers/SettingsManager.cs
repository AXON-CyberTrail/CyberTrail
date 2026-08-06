using UnityEngine;

namespace LightRace3D.Managers
{
    public class SettingsManager : MonoBehaviour
    {
        public static SettingsManager Instance { get; private set; }

        public float masterVolume = 1f;
        public float musicVolume = 0.8f;
        public float sfxVolume = 0.8f;
        public bool enableVSync = true;
        public int targetFrameRate = 60;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadSettings();
        }

        public void LoadSettings()
        {
            // Carregar configurações do disco ou usar padrões.
        }

        public void SaveSettings()
        {
            // Salvar configurações do jogador.
        }
    }
}
