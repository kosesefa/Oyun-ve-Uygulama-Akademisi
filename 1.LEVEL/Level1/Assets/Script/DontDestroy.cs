using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    private void Start()
    {

    }
    private static DontDestroy instance = null;
    public static DontDestroy Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance!=null && instance !=this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }


}
