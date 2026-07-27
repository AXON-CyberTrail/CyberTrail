using UnityEngine;

namespace LightRace3D.Managers
{
    public enum GameModeType
    {
        Classic,
        Flux,
        VersusAI,
        Teams,
        Survival,
        Race
    }

    public class GameModeManager : MonoBehaviour
    {
        public static GameModeManager Instance { get; private set; }
        public GameModeType CurrentMode { get; private set; } = GameModeType.Classic;

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

        public void SetGameMode(GameModeType mode)
        {
            CurrentMode = mode;
            // Configurar regras específicas de cada modo.
        }

        public bool HasTrail()
        {
            return CurrentMode != GameModeType.Race;
        }

        public bool IsDecayTrailMode()
        {
            return CurrentMode == GameModeType.Flux;
        }

        public float GetTrailLifetime()
        {
            return IsDecayTrailMode() ? 10f : Mathf.Infinity;
        }

        public float GetTrailDecayWarningTime()
        {
            return IsDecayTrailMode() ? 2f : 0f;
        }
    }
}
