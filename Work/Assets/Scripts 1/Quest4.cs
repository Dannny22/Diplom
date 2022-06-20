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
                GUI.Box(new Rect((Screen.width - 1200) / 2, (Screen.height - 600) / 2, 1200, 600), "�����");
                GUI.Label(new Rect((Screen.width - 600) / 2 + 5, (Screen.height - 600) / 2 + 15, 600, 600), "-������: � ������� ��������, ��� � �� ��, �� ������� ��� ���� ������. " +
                    "                                 ����� �� ���������� ����� ������ �������� ��� i�'�." +
                    "                                                                                                         -̳���: ����� �� ���� ����, ����� �� ����� ������, ���� ����� ����������." +
                    "�������� �� ��� �� ����, ���� �������� ������� ���� � � ����� �� �� �������� �� �� �������, ����� ����� ���� �������� ������ � ��� �� ��, ���� ���� � ��� ��� �� ��������." +
                    "�� �� ����� ������� ��� �������, � �� ���� �� ��, ����� �� ���� �������� ���� ���� ������ �����. ��� ������ ���� ���� ������ �� ���� ���� ����� ������ � ������ �����.");
                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "�����"))
                {
                    Time.timeScale = 1f;
                    dialog = false;
                    questsManager.fourthDialog = true;
                    questsManager.Deadboss1 = false;
                    questsManager.MissionText = "��������: ��������� � ������� ̳���, � ���� ���� ����� ������";
                    //dialog = true;
                    //GUI.Box(new Rect((Screen.width - 1200) / 2, (Screen.height - 600) / 2, 1200, 600), "�����");
                    //GUI.Label(new Rect((Screen.width - 600) / 2 + 5, (Screen.height - 600) / 2 + 15, 600, 600), "-�����������: ����� �� ������� �������� ���� �� �����? ");
                    //if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "³�������")) ;
                }
            }
            else
            {
                dialog = false;
            }
        }
    }
}
