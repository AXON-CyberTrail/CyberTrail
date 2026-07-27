using UnityEngine;
using LightRace3D.Managers;

namespace LightRace3D.Gameplay
{
    [RequireComponent(typeof(BikeController))]
    public class PlayerController : MonoBehaviour
    {
        public string PlayerId;
        public Color PlayerColor = Color.cyan;

        private BikeController bikeController;

        private void Awake()
        {
            bikeController = GetComponent<BikeController>();
        }

        private void Update()
        {
            if (!GameManager.Instance || !GameManager.Instance.IsMatchActive)
                return;

            ProcessInput();
        }

        private void ProcessInput()
        {
            // Ler entrada do jogador e passar para o BikeController.
            float horizontal = Input.GetAxisRaw("Horizontal");
            bool accelerate = Input.GetKey(KeyCode.W);
            bool brake = Input.GetKey(KeyCode.S);
            bool turbo = Input.GetKey(KeyCode.LeftShift);
            bool emergencyBrake = Input.GetKey(KeyCode.Space);

            bikeController.SetInput(horizontal, accelerate, brake, turbo, emergencyBrake);
        }
    }
}
