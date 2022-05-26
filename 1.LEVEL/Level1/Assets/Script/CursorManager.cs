using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StarterAssets.StarterAssetsInputs.instance.cursorInputForLook = false;
        StarterAssets.StarterAssetsInputs.instance.cursorLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
