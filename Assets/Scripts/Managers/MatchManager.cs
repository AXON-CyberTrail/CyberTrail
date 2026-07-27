using UnityEngine;

namespace LightRace3D.Managers
{
    public class MatchManager : MonoBehaviour
    {
        public static MatchManager Instance { get; private set; }

        public int CurrentPlayers { get; private set; }
        public float MatchTime { get; private set; }

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

        private void Update()
        {
            if (GameManager.Instance != null && GameManager.Instance.IsMatchActive)
            {
                MatchTime += Time.deltaTime;
            }
        }

        public void StartMatch(int playerCount)
        {
            CurrentPlayers = playerCount;
            MatchTime = 0f;
            GameManager.Instance?.StartMatch();
        }

        public void EndMatch()
        {
            GameManager.Instance?.EndMatch();
            // Exibir resultados e resetar estado de partida.
        }
    }
}
