using System.Collections;
using UnityEngine;
using LightRace3D.AI;
using LightRace3D.Gameplay;

namespace LightRace3D.Managers
{
    public class GameBootstrapper : MonoBehaviour
    {
        [Header("Prefabs")]
        public GameObject playerPrefab;
        public GameObject aiPrefab;

        [Header("Spawn")]
        public Transform[] spawnPoints;
        public Transform cameraFollowTarget;

        [Header("Match Settings")]
        public GameModeType defaultGameMode = GameModeType.Flux;
        public int playerCount = 1;
        public int botCount = 3;
        public float startDelay = 3f;

        private void Start()
        {
            PrepareGame();
        }

        private void PrepareGame()
        {
            if (GameModeManager.Instance != null)
            {
                GameModeManager.Instance.SetGameMode(defaultGameMode);
            }

            if (GameManager.Instance != null)
            {
                GameManager.Instance.StartMatch();
            }

            StartCoroutine(DelayedMatchStart());
        }

        private IEnumerator DelayedMatchStart()
        {
            yield return new WaitForSeconds(startDelay);
            SpawnPlayers();
            SpawnBots();
            ActivateCamera();
            UIManager.Instance?.ShowHUD();
            MatchManager.Instance?.StartMatch(playerCount + botCount);
        }

        private void SpawnPlayers()
        {
            for (int i = 0; i < playerCount; i++)
            {
                var spawn = GetSpawnPoint(i);
                if (spawn == null || playerPrefab == null)
                    continue;

                var player = Instantiate(playerPrefab, spawn.position, spawn.rotation);
                player.name = $"Player_{i + 1}";
                var controller = player.GetComponent<PlayerController>();
                if (controller != null)
                {
                    controller.PlayerId = player.name;
                    controller.PlayerColor = Color.cyan;
                }
            }
        }

        private void SpawnBots()
        {
            for (int i = 0; i < botCount; i++)
            {
                var spawn = GetSpawnPoint(playerCount + i);
                if (spawn == null || aiPrefab == null)
                    continue;

                var bot = Instantiate(aiPrefab, spawn.position, spawn.rotation);
                bot.name = $"Bot_{i + 1}";
                var ai = bot.GetComponent<AIController>();
                if (ai != null)
                {
                    ai.difficulty = AIDifficulty.Medium;
                }
            }
        }

        private Transform GetSpawnPoint(int index)
        {
            if (spawnPoints == null || spawnPoints.Length == 0)
                return null;

            return spawnPoints[index % spawnPoints.Length];
        }

        private void ActivateCamera()
        {
            if (cameraFollowTarget != null)
            {
                CameraController.Instance?.SetTarget(cameraFollowTarget);
            }
            else if (spawnPoints != null && spawnPoints.Length > 0)
            {
                var firstPlayer = spawnPoints[0];
                CameraController.Instance?.SetTarget(firstPlayer);
            }
        }

        public void EndMatch()
        {
            MatchManager.Instance?.EndMatch();
            UIManager.Instance?.ShowMatchResults();
        }
    }
}
