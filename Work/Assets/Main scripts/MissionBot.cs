using UnityEngine;
using System.Collections;

public class MissionBot : MonoBehaviour

{

    public bool quest; 
    public bool vis; 
    public string missionText; 
    public string missionTag; 
    private MissionPlayer MP; 

    void Start()

    {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>(); 
    }

    void Update()

    {
        GameObject MissionTagScanner = GameObject.FindGameObjectWithTag("Player"); 
        if (Input.GetKeyDown(KeyCode.E) & Vector3.Distance(transform.position, MissionTagScanner.transform.position) < 2) 
        {
            vis = true; 
        }
    }
    void OnGUI()
    {
        if (vis) 
        {
            if (!quest) 
            {
                GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "�����"); 
                GUI.Label(new Rect((Screen.width - 300) / 2 + 5, (Screen.height - 300) / 2 + 15, 290, 250), "������� ��� �����"); 
                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "��")) 
                {
                    quest = true; 
                    MP.quest = true; 
                    MP.MissionText = "�������� �����"; 
                    MP.ObjectTag = missionTag; 
                    vis = false; 
                }
            }
            else
            { 
                GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "�����");
                GUI.Label(new Rect((Screen.width - 300) / 2 + 5, (Screen.height - 300) / 2 + 15, 290, 250), "������?"); 
                if (MP.MissionObjects) 
                {
                    if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "��")) 
                    {
                        quest = false; 
                        MP.quest = false; 
                        MP.MissionText = ""; 
                        MP.ObjectTag = ""; 
                        MP.MissionObjects = false; 
                        MP.Money = MP.Money + 100; 
                        vis = false; 
                    }
                }
                else
                { 
                    if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "���")) 
                    {
                        vis = false; 
                    }
                }
            }
        }
    }
}
