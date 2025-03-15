using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class OverlayInitialize : MonoBehaviour {

    void Awake() {
        InitOpenVR();
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    private void OnDestroy() {
        CleanUp();
    }

    void InitOpenVR(){
        if(OpenVR.System != null)
            return;
        
        var error = EVRInitError.None;
        OpenVR.Init(ref error, EVRApplicationType.VRApplication_Overlay);
        if(error != EVRInitError.None) {
            throw new System.Exception("Failed to init OpenVR");
        }
    }

    void CleanUp(){
        if(OpenVR.System == null)
            return;
        OpenVR.Shutdown();
    }

}
