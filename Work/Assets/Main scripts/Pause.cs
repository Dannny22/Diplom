using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoCache
{
    public float timer;
    public bool ispause;
    public bool guipause;

    public override void OnTick()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && ispause == false)
        {
            ispause = true;
            gameObject.GetComponent<PlayerHandler>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispause == true)
        {
            ispause = false;
            gameObject.GetComponent<PlayerHandler>().enabled = true;
        }
        if (ispause == true)
        {
            timer = 0;
            guipause = true;
        }
        else if (ispause == false)
        {
            Cursor.visible = false;
            timer = 1f;
            guipause = false;
        }
    } 
    public void OnGUI()
    {
        if (guipause == true)
        {
            Cursor.visible = true;
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 150f, 150f, 45f), "����������"))
            {
                ispause = false;
                timer = 0; 
                gameObject.GetComponent<PlayerHandler>().enabled = true;
            }
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 100f, 150f, 45f), "���������"))
            {

            }
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 50f, 150f, 45f), "���������"))
            {

            }
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2), 150f, 45f), "� ����"))
            {
                
            }
        }
    }
}