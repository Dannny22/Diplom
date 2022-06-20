using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    Quests questsManager;
    Quests2 quests2;
    //QuestFinally questFinally;
    public void Start()
    {
        quests2 = GameObject.FindGameObjectWithTag("Quest2").GetComponent<Quests2>();
        questsManager = GameObject.FindGameObjectWithTag("Quests").GetComponent<Quests>();
        //questFinally = GameObject.FindGameObjectWithTag("QuestFinally").GetComponent<QuestFinally>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Quest2"))
        {
            quests2.dialog = true;
            Cursor.visible = true;
        }
        //if (other.gameObject.CompareTag("QuestFinally"))
        //{
        //    questFinally.dialog = true;
        //    Cursor.visible = true;
        //}
    }
    public void Update()
    {
        
    }
    public void OnGUI()
    {
        
        GUI.Label(new Rect(20, 200, 300, 50), " " + questsManager.MissionText);
        if (questsManager.Deadboss1)
        {
            GUI.Label(new Rect(150, 200, 215, 30), "[Демона вбито]");
            questsManager.MissionText = "Поговоріть з Міурою";
        }
        if (questsManager.Deadboss2)
        {
            GUI.Label(new Rect(170, 200, 215, 30), "[Темного мечника вбито]");
            questsManager.MissionText = "Поговоріть з Кортезом";
        }
    }
}
