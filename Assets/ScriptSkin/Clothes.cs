using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clothes", menuName = "Create Clothes", order = 1)]
public class Clothes : ScriptableObject {
    [SerializeField] private List<item> clothes = new List<item>();
    
    public List<item> GetClothes() {
        return clothes;
    }
}

[Serializable]
public class item {
    public Mesh mesh;
    public List<Material> materials = new List<Material>();
}
