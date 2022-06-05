using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = true;
        StarterAssets.StarterAssetsInputs.instance.cursorLocked = true;
        Cursor.lockState = CursorLockMode.None;
        StarterAssets.ThirdPersonController.LockCameraPosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
