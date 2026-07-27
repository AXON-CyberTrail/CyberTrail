using UnityEngine;

namespace LightRace3D.Utilities
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public float GetHorizontal()
        {
            return Input.GetAxisRaw("Horizontal");
        }

        public bool GetAccelerate()
        {
            return Input.GetKey(KeyCode.W);
        }

        public bool GetBrake()
        {
            return Input.GetKey(KeyCode.S);
        }

        public bool GetTurbo()
        {
            return Input.GetKey(KeyCode.LeftShift);
        }

        public bool GetEmergencyBrake()
        {
            return Input.GetKey(KeyCode.Space);
        }
    }
}
