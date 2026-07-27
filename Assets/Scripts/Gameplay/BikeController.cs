using UnityEngine;

namespace LightRace3D.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class BikeController : MonoBehaviour
    {
        [Header("Identificação")]
        public string playerId = "Player";
        public Color trailColor = Color.cyan;

        [Header("Velocidades")]
        public float baseSpeed = 40f;
        public float turboSpeed = 55f;
        public float brakeSpeed = 25f;

        [Header("Turbo")]
        public float maxTurboEnergy = 100f;
        public float turboDrainRate = 20f;
        public float turboRechargeRate = 10f;

        [Header("Trilha")]
        public float trailSpawnDistance = 0.5f;

        public float CurrentSpeed { get; private set; }

        private Rigidbody bikeRigidbody;
        private float currentTurboEnergy;
        private float inputDirection;
        private bool isAccelerating;
        private bool isBraking;
        private bool isTurbo;
        private bool isEmergencyBrake;
        private Vector3 lastTrailPosition;

        private void Awake()
        {
            bikeRigidbody = GetComponent<Rigidbody>();
            currentTurboEnergy = maxTurboEnergy;
            lastTrailPosition = transform.position;
        }

        private void FixedUpdate()
        {
            UpdateMovement();
            UpdateTurbo();
        }

        public void SetInput(float direction, bool accelerate, bool brake, bool turbo, bool emergencyBrake)
        {
            inputDirection = direction;
            isAccelerating = accelerate;
            isBraking = brake;
            isTurbo = turbo;
            isEmergencyBrake = emergencyBrake;
        }

        private void UpdateMovement()
        {
            float speed = baseSpeed;

            if (isTurbo && currentTurboEnergy > 0f)
            {
                speed = turboSpeed;
            }
            else if (isBraking)
            {
                speed = brakeSpeed;
            }

            CurrentSpeed = speed;
            Vector3 forward = transform.forward * speed * Time.fixedDeltaTime;
            bikeRigidbody.MovePosition(bikeRigidbody.position + forward);

            if (Mathf.Abs(inputDirection) > 0.1f)
            {
                float turnAngle = inputDirection * 90f * Time.fixedDeltaTime;
                transform.Rotate(Vector3.up, turnAngle);
            }

            if (isEmergencyBrake)
            {
                bikeRigidbody.velocity = Vector3.zero;
            }

            if (Vector3.Distance(lastTrailPosition, transform.position) >= trailSpawnDistance)
            {
                TrailManager.Instance?.CreateTrailSegment(playerId, transform.position, transform.rotation, trailColor);
                lastTrailPosition = transform.position;
            }
        }

        private void UpdateTurbo()
        {
            if (isTurbo && currentTurboEnergy > 0f)
            {
                currentTurboEnergy = Mathf.Max(currentTurboEnergy - turboDrainRate * Time.fixedDeltaTime, 0f);
            }
            else if (!isTurbo)
            {
                currentTurboEnergy = Mathf.Min(currentTurboEnergy + turboRechargeRate * Time.fixedDeltaTime, maxTurboEnergy);
            }
        }

        public float GetTurboEnergy() => currentTurboEnergy;
    }
}
