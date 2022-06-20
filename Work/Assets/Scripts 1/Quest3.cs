using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest3 : MonoBehaviour
{
    Quests questsManager;
    public bool quest;
    public bool dialog;
    public string missionText;
    public string missionTag;
    private MissionPlayer MP;
    public GameObject MiniBoss;
    
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
            if (!quest && !questsManager.thirdDialog && questsManager.secondDialog)
            {
                Time.timeScale = 0;
                GUI.Box(new Rect((Screen.width - 1200) / 2, (Screen.height - 600) / 2, 1200, 600), "Квест");
                GUI.Label(new Rect((Screen.width - 600) / 2 + 5, (Screen.height - 600) / 2 + 15, 600, 600), "-Дейвіон: Ти Міура ? Мені сказали ти можешь знати де Райган ?" +
                    "                                           -Міура: Мені знайоме твоє обличчя. Не хвилюйся я тебе не розкрию бунтівний лицар Дейвіон, проте ти виконаєш для мене роботку. " +
                    "Демон що захопив магічний ліс, завдає шкоди моїй діяльності, знищи його і я відповім на твої питання.");
                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "Погодитись"))
                {
                    Time.timeScale = 1f;
                    Cursor.visible = false;
                    dialog = false;
                    questsManager.thirdDialog = true;
                    questsManager.MissionText = "Завдання: Вбити демона в магічному лісі";
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

