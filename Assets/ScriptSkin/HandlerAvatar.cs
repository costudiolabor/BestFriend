using UnityEngine;

public class HandlerAvatar : MonoBehaviour {
    [SerializeField] private MeshFilter hair;
    [SerializeField] private SkinnedMeshRenderer avatar;
    [SerializeField] private SkinnedMeshRenderer clothingTop;
    [SerializeField] private SkinnedMeshRenderer clothingPants;
    [SerializeField] private SkinnedMeshRenderer clothingShoes;

    public void SetColSkin(Material material) {
        var sharedMaterials = avatar.sharedMaterials;
        sharedMaterials[0] = material;
        avatar.sharedMaterials = sharedMaterials;
    } 

    public void SetHair(Mesh mesh) {
       hair.mesh = mesh;
    }
    
    public void SetColHair(Material material) { 
        var meshRendererHair = hair.GetComponent<MeshRenderer>();
        var sharedMaterialsHair = meshRendererHair.sharedMaterials;
        sharedMaterialsHair[0] = material;
        meshRendererHair.sharedMaterials = sharedMaterialsHair;
            
        var sharedMaterials = avatar.sharedMaterials;
        sharedMaterials[1] = material;
        sharedMaterials[2] = material;
        sharedMaterials[4] = material;
        avatar.sharedMaterials = sharedMaterials;
    }
    
    public void SetColEyes(Material material) {
        var sharedMaterials = avatar.sharedMaterials;
        sharedMaterials[5] = material;
        avatar.sharedMaterials = sharedMaterials;
    }
    
    public void SetTop(int i) {
       // var item = tops.GetItems();
       // clothingTop.sharedMesh = item[i].mesh;
    }
    
    public void SetColTop(int i) {
        //var item = tops.GetItems();
        //var sharedMaterials = clothingTop.sharedMaterials;
        //sharedMaterials[0] = material;
        //clothingTop.sharedMaterials = sharedMaterials;
    }
   
    public void SetPants(int i) {
        //var item = pants.GetItems();
        //clothingPants.sharedMesh = item[i].mesh;
    }
    
    public void SetColPants(int i) {
        //var item = pants.GetItems();
        //var material = pants.GetItems()[_pants].materials[i];
        //var sharedMaterials = clothingPants.sharedMaterials;
        //sharedMaterials[0] = material;
        //clothingPants.sharedMaterials = sharedMaterials;
    }
}
