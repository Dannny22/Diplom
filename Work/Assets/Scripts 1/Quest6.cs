using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest6 : MonoBehaviour
{
    Quests questsManager;
    public bool quest;
    public bool dialog;
    public string missionText;
    public string missionTag;
    private MissionPlayer MP;

    void Start()
    {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>();
        questsManager = GameObject.FindGameObjectWithTag("Quests").GetComponent<Quests>();
    }


    void Update()
    {
        GameObject MissionTagScanner = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetKeyDown(KeyCode.E) & Vector3.Distance(transform.position, MissionTagScanner.transform.position) < 2)
        {
            dialog = true;
            Cursor.visible = true;
        }
    }
    public void OnGUI()
    {
        if (dialog)
        {
            if (!quest && !questsManager.sixthDialog && questsManager.fifthDialog)
            {
                Time.timeScale = 0;
                GUI.Box(new Rect((Screen.width - 1200) / 2, (Screen.height - 600) / 2, 1200, 600), "Квест");
                GUI.Label(new Rect((Screen.width - 600) / 2 + 5, (Screen.height - 600) / 2 + 15, 600, 600), "-Дейвіон: Привіт, ти госодар цієї ферми ? Я шукаю свого друга Райгана, останній раз його бачили на твоїй фермі. " +

                    "                                                                                                                              -Кортез: Так, це моя ферма. Я тобі розповім де ти можешь знайти свого друга, але тільки якщо ти мені допоможешь." +
                    "                                                                                                                               -Дейвіон: Що потрібно зробити ?" +
                    "                                                                                                                               -Кортез:  Бачишь цього вовка, його прогнав із логова Темний мечник. Якщо ти допоможешь цьому вовку я допоможу тобі.");
                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "Домовились"))
                {
                    Time.timeScale = 1f;
                    dialog = false;
                    questsManager.sixthDialog = true;
                    questsManager.Deadboss1 = false;
                    questsManager.MissionText = "Завдання: Здолати Темного мечника";
                    //dialog = true;
                    //GUI.Box(new Rect((Screen.width - 1200) / 2, (Screen.height - 600) / 2, 1200, 600), "Квест");
                    //GUI.Label(new Rect((Screen.width - 600) / 2 + 5, (Screen.height - 600) / 2 + 15, 600, 600), "-Незнайомець: Думаю ви зможете дізнатися щось на ринку? ");
                    //if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "Відповісти")) ;
                }
            }
            else
            {
                dialog = false;
            }
        }
    }
}