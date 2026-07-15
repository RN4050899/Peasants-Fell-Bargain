using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetTheGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void resetGoNext()
    {
        try
        {
            Destroy(GameObject.Find("Player"));
        }
        catch
        {
            // :(
        }
    }
}
