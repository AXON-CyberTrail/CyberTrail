using UnityEngine;

namespace LightRace3D.Multiplayer
{
    public class NetworkManager : MonoBehaviour
    {
        public static NetworkManager Instance { get; private set; }

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

        public void CreateLobby()
        {
            // Iniciar sistema de criação de sala.
        }

        public void JoinLobby(string code)
        {
            // Entrar em sala por código.
        }

        public void StartMatch()
        {
            // Sincronizar início de partida para jogadores conectados.
        }
    }
}
