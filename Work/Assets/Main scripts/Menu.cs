using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
        {
            SceneManager.LoadScene(0);
        }
    

    public void ExitGame()
        {
            Debug.Log("���� ���������");
            Application.Quit();
        }
}
