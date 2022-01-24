using UnityEngine;
using System.Collections;
public class MissionPlayer : MonoBehaviour
{
    public bool quest; 
    public string MissionText; 
    public string ObjectTag; 
    public bool MissionObjects; 
    public int Money; 

    void OnGUI()
    {

        if (quest)
        {
            GUI.Label(new Rect(20, 200, 300, 30), " " + MissionText); 
            if (MissionObjects)
            {
                GUI.Label(new Rect(150, 200, 200, 30), "[������� ������]"); 
            }
        }
        GUI.Label(new Rect(20, 150, 100, 30), "������: " + Money); 
    }
}
