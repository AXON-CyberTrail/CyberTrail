using UnityEngine;

namespace LightRace3D.Managers
{
    public class LobbyManager : MonoBehaviour
    {
        public static LobbyManager Instance { get; private set; }

        public int maxPlayers = 8;
        public string lobbyCode;

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

        public void CreateLobby(int playerCount)
        {
            // Criar lobby local ou online.
            playerCount = Mathf.Clamp(playerCount, 2, maxPlayers);
        }

        public void JoinLobby(string code)
        {
            // Lógica de entrar em lobby existente.
            lobbyCode = code;
        }

        public void LeaveLobby()
        {
            // Sair do lobby e limpar estado.
            lobbyCode = string.Empty;
        }
    }
}