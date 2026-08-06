using UnityEngine;
using UnityEngine.SceneManagement;

namespace LightRace3D.Managers
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }

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

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void LoadLobby()
        {
            SceneManager.LoadScene("Lobby");
        }

        public void LoadArena()
        {
            SceneManager.LoadScene("Arena");
        }

        public void LoadResults()
        {
            SceneManager.LoadScene("Results");
        }
    }
}
