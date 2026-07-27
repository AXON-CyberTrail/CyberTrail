using UnityEngine;
using LightRace3D.Managers;

namespace LightRace3D.AI
{
    public enum AIDifficulty
    {
        Easy,
        Medium,
        Hard,
        Insane
    }

    [RequireComponent(typeof(Gameplay.BikeController))]
    public class AIController : MonoBehaviour
    {
        public AIDifficulty difficulty = AIDifficulty.Medium;
        public float decisionInterval = 0.2f;

        private Gameplay.BikeController bikeController;
        private float timer;

        private void Awake()
        {
            bikeController = GetComponent<Gameplay.BikeController>();
        }

        private void Update()
        {
            if (!Managers.GameManager.Instance || !Managers.GameManager.Instance.IsMatchActive)
                return;

            timer += Time.deltaTime;
            if (timer >= decisionInterval)
            {
                timer = 0f;
                MakeDecision();
            }
        }

        private void MakeDecision()
        {
            // Comportamento base; deve ser expandido para cada dificuldade.
            float direction = Random.Range(-1f, 1f);
            bikeController.SetInput(direction, true, false, false, false);
        }
    }
}
