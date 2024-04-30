using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    //TextMeshProÇégÇ§Ç∆Ç´ÇÕñYÇÍÇ»Ç¢ÇÊÇ§Ç…íçà”ÅI
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    float time = 30.0f;
    GameObject generator;
    GameObject hpGauge;
    GameObject staminaGauge;


    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.generator = GameObject.Find("ArrowGenerator");
        this.hpGauge = GameObject.Find("hpGauge");
        this.staminaGauge = GameObject.Find("staminaGauge");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;

        if(MenuSelect.Level == 0)
        {
            EasyMode(this.time);
        }
        else if(MenuSelect.Level == 1)
        {
            NormalMode(this.time);
        }
        else if(MenuSelect.Level == 2)
        {
            HardMode(this.time);
        }

        this.timerText.GetComponent<TextMeshProUGUI>().text =
            this.time.ToString("F1");
        if(this.time <= 0)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }

    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.2f;
    }

    public void DecreaseStamina()
    {
        this.staminaGauge.GetComponent<Image>().fillAmount -= 0.3f;
    }

    public bool CheckHp()
    {
        bool check;
        if (this.hpGauge.GetComponent<Image>().fillAmount < 0.001)
        {
            check = true;
        }
        else
        {
            check = false;
        }
        return check;
    }

    /*public bool CheckStamina()
    {
        bool check;
        if (this.staminaGauge.GetComponent<Image>().fillAmount > 0)
        {
            check = true;
        }
        else
        {
            check = false;
        }
        return check;
    }

    public void RecoverStamina()
    {
        this.staminaGauge.GetComponent<Image>().fillAmount += 0.04f;
    }*/

    void HardMode(float time)
    {
        if (time < 4)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                0.95f, -0.16f, 0);
        }
        else if (4 <= time && time < 10)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                1.0f, -0.15f, 0);

        }
        else if (10 <= time && time < 20)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                1.13f, -0.13f, 0);
        }
        else if (20 <= time && time < 30)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                1.3f, -0.11f, 0);
        }
        else if (30 <= time)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                 1.38f, -0.9f, 0);
        }
    }
    void EasyMode(float time)
    {
        if (time < 4)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                1.2f, -0.10f, 0);
        }
        else if (4 <= time && time < 10)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                1.2f, -0.10f, 0);

        }
        else if (10 <= time && time < 20)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                1.3f, -0.10f, 0);
        }
        else if (20 <= time && time < 30)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                1.5f, -0.10f, 0);
        }
        else if (30 <= time)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                 1.8f, -0.9f, 0);
        }
    }
    void NormalMode(float time)
    {
        if (time < 4)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                1.0f, -0.15f, 0);
        }
        else if (4 <= time && time < 10)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                1.1f, -0.13f, 0);

        }
        else if (10 <= time && time < 20)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                1.2f, -0.13f, 0);
        }
        else if (20 <= time && time < 30)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                1.4f, -0.11f, 0);
        }
        else if (30 <= time)
        {
            this.generator.GetComponent<ArrowGenerator>().SetParameter(
                1.5f, -0.10f, 0);
        }
    }
}
