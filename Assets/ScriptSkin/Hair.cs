using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Hair", menuName = "Create Hair", order = 1)]

public class Hair : ScriptableObject {
    [SerializeField] private List<ItemHair> itemHairs = new List<ItemHair>();
    [SerializeField] private List<Material> materials = new List<Material>();

    public List<ItemHair> GetItemHairs() {
        return itemHairs;
    }
    
    public List<Material> GetMaterials() {
        return materials;
    }
}

[Serializable]
public class ItemHair {
    public Mesh mesh;
    public Texture texture;
}

