using UnityEngine;

namespace LightRace3D.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

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

        public void PlaySFX(string soundName)
        {
            // Tocar efeito sonoro no jogo.
        }

        public void PlayMusic(string trackName)
        {
            // Reproduzir trilha sonora.
        }
    }
}
