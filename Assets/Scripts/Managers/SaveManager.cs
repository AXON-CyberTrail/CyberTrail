using UnityEngine;

namespace LightRace3D.Managers
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; private set; }

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

        public void SavePlayerData(PlayerData data)
        {
            // Serializar e salvar dados do jogador.
        }

        public PlayerData LoadPlayerData()
        {
            // Carregar dados do jogador do disco.
            return new PlayerData();
        }
    }

    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int wins;
        public int losses;
        public int kills;
        public int deaths;
        public float totalPlayTime;
    }
}