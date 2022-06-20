using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4 : MonoBehaviour
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
            if (!quest && !questsManager.fourthDialog && questsManager.Deadboss1)
            {
                Time.timeScale = 0;
                GUI.Box(new Rect((Screen.width - 1200) / 2, (Screen.height - 600) / 2, 1200, 600), "Квест");
                GUI.Label(new Rect((Screen.width - 600) / 2 + 5, (Screen.height - 600) / 2 + 15, 600, 600), "-Дейвіон: Я виконав завдання, але є де що, що здається мені дуже дивним. " +
                    "                                 Демон на останньому своєму подиху промовив твоє iм'я." +
                    "                                                                                                         -Міура: Цього не може бути, схоже що перед смертю, його розум прокинувся." +
                    "Насправді це був мій брат, його захопила нечиста сила і я більше не міг дивитись як він страждає, проте вбити його власними руками я теж не міг, саме тому я дав тобі це завдання." +
                    "Що до твого питання про Райгана, я не знаю де він, проте на мене працюють люди котрі можуть знати. Моя людина буде тебе чекати на місці куди вказує стрілка з золотої статуї.");
                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "Дякую"))
                {
                    Time.timeScale = 1f;
                    dialog = false;
                    questsManager.fourthDialog = true;
                    questsManager.Deadboss1 = false;
                    questsManager.MissionText = "Завдання: Зустрітися з людиною Міури, в місці куди вказує стрілка";
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
