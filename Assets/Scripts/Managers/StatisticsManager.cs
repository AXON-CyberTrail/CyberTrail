using UnityEngine;

namespace LightRace3D.Managers
{
    public class StatisticsManager : MonoBehaviour
    {
        public static StatisticsManager Instance { get; private set; }

        public int totalWins;
        public int totalLosses;
        public int totalKills;
        public int totalDeaths;
        public float totalPlayTime;
        public int currentWinStreak;
        public int bestWinStreak;

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

        public void RegisterMatchResult(bool won)
        {
            if (won)
            {
                totalWins++;
                currentWinStreak++;
                bestWinStreak = Mathf.Max(bestWinStreak, currentWinStreak);
            }
            else
            {
                totalLosses++;
                currentWinStreak = 0;
            }
        }

        public void RegisterKill()
        {
            totalKills++;
        }

        public void RegisterDeath()
        {
            totalDeaths++;
        }
    }
}