using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoCache
{
    public GameObject Skill1;
    public GameObject Skill2;
    public float CountdownSkill1 = 0f;
    public float CountdownSkill2 = 0f;
    public float Mana = 1f;
    public Image UIMana;
    public int time = 0;
    public Text UISkill1Time;
    public Text UISkill2Time;
    public AudioSource Skill1Sound;
    public AudioSource Skill2Sound;

    public override void OnTick()
    {
        UIMana.fillAmount = Mana;
        Mana += Time.deltaTime / 25f;
        if (Mana > 1f)
        {
            Mana = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) & CountdownSkill1 <= 0 & Mana >= 0.25f)
        {
            Skill1Sound.Play();
            Instantiate(Skill1, transform.position, transform.rotation);
            CountdownSkill1 = 6f;
            Mana = Mana - 0.25f;
            StartCoroutine(Skill1Time());
        }
        if (CountdownSkill1 <= 0)
        {
            //UISkill1.gameObject.SetActive(false);
            UISkill1Time.gameObject.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.Alpha2) & CountdownSkill2 <= 0 & Mana >= 0.5f)
        {
            Skill2Sound.Play();
            Instantiate(Skill2, transform.position, transform.rotation);
            CountdownSkill2 = 11f;
            Mana = Mana - 0.5f;
            StartCoroutine(Skill2Time());
        }
        if (CountdownSkill2 <= 0)
        {
            UISkill2Time.gameObject.SetActive(false);
        }
    } 
    private IEnumerator Skill1Time()
    {
        while (CountdownSkill1 > 0)
        {
            CountdownSkill1 = CountdownSkill1 - 1f;
            //UISkill1.gameObject.SetActive(true);
            UISkill1Time.gameObject.SetActive(true);
            UISkill1Time.text = "" + CountdownSkill1;
            //UISkill1.fillAmount = CountdownSkill1 / 2.5f;
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator Skill2Time()
    {
        while (CountdownSkill2 > 0)
        {
            CountdownSkill2 = CountdownSkill2 - 1f;
            //UISkill1.gameObject.SetActive(true);
            UISkill2Time.gameObject.SetActive(true);
            UISkill2Time.text = "" + CountdownSkill2;
            //UISkill1.fillAmount = CountdownSkill1 / 2.5f;
            yield return new WaitForSeconds(1f);
        }
    }
}
