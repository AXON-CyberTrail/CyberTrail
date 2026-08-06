using System.Collections.Generic;
using UnityEngine;

namespace LightRace3D.Managers
{
    public enum PowerUpType
    {
        InfiniteTurbo,
        Shield,
        StealthTrail,
        DoubleTrail,
        WideTrail,
        EMP,
        ShortTeleport,
        EnemyTurboFreeze
    }

    public class PowerUpManager : MonoBehaviour
    {
        public static PowerUpManager Instance { get; private set; }

        private readonly Dictionary<PowerUpType, float> activeDurations = new();

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

        public void ActivatePowerUp(string playerId, PowerUpType powerUp)
        {
            // Ativar efeito específico para jogador.
        }

        public void DeactivatePowerUp(string playerId, PowerUpType powerUp)
        {
            // Desativar efeito após duração.
        }
    }
}
