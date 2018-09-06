using UnityEngine;
using System.Collections;

public class EnterName : MonoBehaviour
{

    public GUIText gt;
    private System.String playerName;
    void Start()
    {
        gt = GetComponent<GUIText>();
    }
    void OnGUI()
    {
        
        playerName = GUI.TextField(new Rect(0,0.1f,2,1), playerName);
    }
    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == "\b"[0])
                if (gt.text.Length != 0)
                    gt.text = gt.text.Substring(0, gt.text.Length - 1);

                else
                if (c == "\n"[0] || c == "\r"[0])
                    print("User entered his name: " + gt.text);
                else
                    gt.text += c;
        }
    }
    
}