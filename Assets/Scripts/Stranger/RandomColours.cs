using UnityEngine;

namespace Stranger
{
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public class RandomColours : MonoBehaviour
    {
        [SerializeField] private Material[] _shirtMaterials;
        [SerializeField] private Material[] _trouserMaterials;
        [SerializeField] private Material[] _skinMaterials;
        [SerializeField] private Material[] _shoeMaterials;
        private SkinnedMeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<SkinnedMeshRenderer>();
        }

        private void Start()
        {
            // Choose the random materials.
            var randomShirtIndex = Random.Range(0, _shirtMaterials.Length);
            var randomShirtMaterial = _shirtMaterials[randomShirtIndex];
            
            var randomTrouserIndex = Random.Range(0, _trouserMaterials.Length);
            var randomTrouserMaterial = _trouserMaterials[randomTrouserIndex];
            
            var randomSkinIndex = Random.Range(0, _skinMaterials.Length);
            var randomSkinMaterial = _skinMaterials[randomSkinIndex];
            
            var randomShoeIndex = Random.Range(0, _shoeMaterials.Length);
            var randomShoeMaterial = _shoeMaterials[randomShoeIndex];
            
            // Assign the random materials.
            _meshRenderer.materials = new[]
            {
                null,
                randomTrouserMaterial,
                randomShirtMaterial,
                randomShoeMaterial,
                randomSkinMaterial,
                randomSkinMaterial,
                randomSkinMaterial
            };
        }
    }
}