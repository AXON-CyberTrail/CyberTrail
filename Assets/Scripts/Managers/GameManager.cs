using UnityEngine;

namespace LightRace3D.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public bool IsMatchActive { get; private set; }

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

        private void Start()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Inicializa sistemas centrais do jogo.
            // Ex: configurações, áudio, UI e redes.
        }

        public void StartMatch()
        {
            IsMatchActive = true;
            // Iniciar o gerenciador de partidas.
        }

        public void EndMatch()
        {
            IsMatchActive = false;
            // Encerrar partida e mostrar resultados.
        }
    }
}
