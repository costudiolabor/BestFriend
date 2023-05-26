using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsModel", menuName = "Create SettingsModel", order = 1)]
public class SettingsModel : ScriptableObject {
   [SerializeField] private Hair hair;
   [SerializeField] private MaterialsAvatar materialsEyes;
   [SerializeField] private MaterialsAvatar materialsSkin;
   [SerializeField] private Clothes tops;
   [SerializeField] private Clothes pants;
   [SerializeField] private Clothes shoes;

   public List<ItemHair> GetItemHairs() {
      return hair.GetItemHairs();
   }
   
   public List<Material> GetColHair() {
      return hair.GetMaterials();
   }

   public List<Material> GetColSkins()
   {
      return materialsSkin.GetMaterials();
   }
   
   public List<Material> GetColEyes()
   {
      return materialsEyes.GetMaterials();
   }
}
