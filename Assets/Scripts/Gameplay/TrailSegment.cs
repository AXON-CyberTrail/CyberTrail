using UnityEngine;

namespace LightRace3D.Gameplay
{
    public class TrailSegment : MonoBehaviour
    {
        private Renderer segmentRenderer;
        private Collider segmentCollider;
        private MaterialPropertyBlock propertyBlock;
        private Color baseColor;
        private float remainingLife;
        private float decayWarningTime;
        private bool isActiveSegment;

        private static readonly int ColorId = Shader.PropertyToID("_Color");
        private static readonly int EmissionId = Shader.PropertyToID("_EmissionColor");

        private void Awake()
        {
            segmentRenderer = GetComponent<Renderer>();
            segmentCollider = GetComponent<Collider>();
            propertyBlock = new MaterialPropertyBlock();
            ResetSegment();
        }

        private void Update()
        {
            if (!isActiveSegment)
                return;

            if (float.IsInfinity(remainingLife))
                return;

            remainingLife -= Time.deltaTime;
            if (remainingLife <= 0f)
            {
                Expire();
                return;
            }

            if (decayWarningTime > 0f && remainingLife <= decayWarningTime)
            {
                float t = Mathf.Clamp01(remainingLife / decayWarningTime);
                UpdateDecayVisuals(t);
            }
        }

        public void SetColor(Color color)
        {
            baseColor = color;
            if (segmentRenderer != null)
            {
                segmentRenderer.GetPropertyBlock(propertyBlock);
                propertyBlock.SetColor(ColorId, baseColor);
                propertyBlock.SetColor(EmissionId, baseColor);
                segmentRenderer.SetPropertyBlock(propertyBlock);
            }
        }

        public void Initialize(float lifetime, float warningTime)
        {
            isActiveSegment = true;
            remainingLife = lifetime <= 0f ? Mathf.Infinity : lifetime;
            decayWarningTime = lifetime <= 0f ? 0f : warningTime;

            if (segmentCollider != null)
            {
                segmentCollider.enabled = true;
            }

            gameObject.SetActive(true);
            UpdateDecayVisuals(1f);
        }

        private void UpdateDecayVisuals(float intensity)
        {
            if (segmentRenderer == null)
                return;

            segmentRenderer.GetPropertyBlock(propertyBlock);
            var emissionColor = baseColor * Mathf.Lerp(0.2f, 1f, intensity);
            emissionColor.a = intensity;
            propertyBlock.SetColor(EmissionId, emissionColor);
            propertyBlock.SetColor(ColorId, baseColor);
            segmentRenderer.SetPropertyBlock(propertyBlock);
        }

        public void ResetSegment()
        {
            isActiveSegment = false;
            remainingLife = 0f;
            decayWarningTime = 0f;

            if (segmentCollider != null)
            {
                segmentCollider.enabled = false;
            }

            gameObject.SetActive(false);
        }

        private void Expire()
        {
            ResetSegment();
            TrailPool.Instance?.ReturnSegment(this);
        }
    }
}
