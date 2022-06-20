using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest7 : MonoBehaviour
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
            if (!quest && !questsManager.seventhDialog && questsManager.Deadboss2)
            {
                Time.timeScale = 0;
                GUI.Box(new Rect((Screen.width - 1200) / 2, (Screen.height - 600) / 2, 1200, 600), "Квест");
                GUI.Label(new Rect((Screen.width - 600) / 2 + 5, (Screen.height - 600) / 2 + 15, 600, 600), "-Дейвіон: Я виконав свою частину наших домовленостей, вовк може йти до себе в логово. " +

                    "                                                                                                                              -Кортез: Справді ? Дякую тобі. Я добре знаю Райгана, якось він прийшов до мене і сказав що збирається очистити руїни від нежиті, після того я його більше не зустрічав, сподіваюсь з ним все гаразд");
                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "Зрозумів"))
                {
                    Time.timeScale = 1f;
                    dialog = false;
                    questsManager.seventhDialog = true;
                    questsManager.Deadboss2 = false;
                    questsManager.MissionText = "Завдання: Йди до руїн";
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
