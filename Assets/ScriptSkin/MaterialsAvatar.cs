using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialsAvatar", menuName = "Create MaterialsAvatar", order = 1)]
public class MaterialsAvatar : ScriptableObject {
    [SerializeField] private List<Material> materials = new List<Material>();

    public List<Material> GetMaterials() {
        return materials;
    }
}
