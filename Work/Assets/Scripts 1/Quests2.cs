using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests2 : MonoBehaviour
{
    Quests questsManager;
    public bool quest;
    public bool dialog;
    public string missionText;
    public string missionTag;
    private MissionPlayer MP;
    public void Start()
    {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>();
        questsManager = GameObject.FindGameObjectWithTag("Quests").GetComponent<Quests>();
    }

    public void Update()
    {
        GameObject MissionTagScanner = GameObject.FindGameObjectWithTag("Player");
        //if (Input.GetKeyDown(KeyCode.E) & Vector3.Distance(transform.position, MissionTagScanner.transform.position) < 2 & questsManager.firstDialog)
        //{
        //    dialog = true;
        //    Cursor.visible = true;
        //}
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Quest2"))
    //    {
    //        dialog = true;
    //        Cursor.visible = true;
    //    }
    //}
    public void OnGUI()
    {
        if (dialog)
        {
            if (!quest && !questsManager.secondDialog && questsManager.firstDialog)
            {
                Time.timeScale = 0;
                GUI.Box(new Rect((Screen.width - 1200) / 2, (Screen.height - 600) / 2, 1200, 600), "Квест");
                GUI.Label(new Rect((Screen.width - 600) / 2 + 5, (Screen.height - 600) / 2 + 15, 600, 600), "-Варта: Стояти, в селище аби кого не пускають. " +
                   "                                                                                         Бачу ви не місцевий. Для чого ви прямуєте в село ? " + "                                                                                                                -Дейвіон: Я Дейвіон, шукаю мого колишнього товариша  Райгана" +
                    "                                                                                                   -Варта: Швидше за все, маг Міура знає де Райган, він стоїть біля магічної крамниці. ");
                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "До зустрічі"))
                {
                    Time.timeScale = 1f;
                    Cursor.visible = false;
                    dialog = false;
                    questsManager.secondDialog = true;
                    questsManager.MissionText = "Завдання: Йдіть до Міури";
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

