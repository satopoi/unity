using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInChecker : MonoBehaviour
{
    public Hole Red;
    public Hole Blue;
    public Hole Green;

    void OnGUI()
    {
        string label = " ";

        // すべてのボールが入ったらラベルを表示
        if (Red.IsFallIn() && Blue.IsFallIn() && Green.IsFallIn())
        {
            label = "Fall In hole!!!";
        }
        GUI.Label (new Rect(0, 0, 100, 30), label);
    }
}
