using System;
using UnityEngine;

[Serializable]
public class CameraHandler {
    [SerializeField] private Transform camera;
    [SerializeField] private Transform pointMain;
    [SerializeField] private Transform pointCustomer;

    public void Initialize() {
        SetPointMainCamera();
    }
    
    public void SetPointMainCamera() {
        camera.SetParent(pointMain);
        ResetCamera();
    }
    
    public void SetPointCustomerCamera() {
        camera.SetParent(pointCustomer);
        ResetCamera();
    }
    
    private void ResetCamera() {
        camera.localPosition = new Vector3(0, 0, 0);
        camera.rotation = new Quaternion(0, 0, 0, 0);
    }
}