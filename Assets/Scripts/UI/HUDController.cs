using UnityEngine;
using UnityEngine.UI;
using LightRace3D.Gameplay;

namespace LightRace3D.UI
{
    public class HUDController : MonoBehaviour
    {
        public Text speedText;
        public Image turboBar;
        public Text playersAliveText;
        public Text matchTimeText;
        public Text pingText;
        public Text fpsText;

        private BikeController playerBike;

        private void Start()
        {
            playerBike = FindObjectOfType<BikeController>();
        }

        private void Update()
        {
            if (playerBike != null)
            {
                speedText.text = $"{playerBike.CurrentSpeed:0} km/h";
                turboBar.fillAmount = playerBike.GetTurboEnergy() / playerBike.maxTurboEnergy;
            }

            if (Managers.MatchManager.Instance != null)
            {
                matchTimeText.text = $"Tempo: {Managers.MatchManager.Instance.MatchTime:0}s";
            }

            // Ping e FPS são placeholders até integração real de rede.
            pingText.text = "Ping: 0 ms";
            fpsText.text = $"FPS: {1f / Time.deltaTime:0}";
        }
    }
}
