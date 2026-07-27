using UnityEngine;

namespace LightRace3D.Gameplay
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class TrailRenderer : MonoBehaviour
    {
        public float width = 0.3f;
        public Color trailColor = Color.cyan;

        private void Awake()
        {
            // Configurar renderização do rastro e materiais.
        }

        public void SetTrailColor(Color color)
        {
            trailColor = color;
            // Atualizar material ou emissive color do trail.
        }
    }
}
