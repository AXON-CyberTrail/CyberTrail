using UnityEngine;

namespace LightRace3D.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

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

        public void ShowMainMenu()
        {
            // Exibir menu principal.
        }

        public void ShowHUD()
        {
            // Habilitar HUD de jogo.
        }

        public void ShowMatchResults()
        {
            // Exibir resultados de partida.
        }
    }
}
