using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;    //TextMeshProを使うときは忘れないように注意！
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator = null;
    float jumpForce = 380.0f;
    float downForce = -3.0f;
    float time = 30.0f;
    float stime = 0f;
    public GameObject baria_prefab;
    public static Vector3 Playerpos;
    int cnt = 2;
    GameObject Cnt;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.Cnt = GameObject.Find("ShieldCnt");

    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;
        GameObject director = GameObject.Find("GameDirector");
        //ジャンプする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            animator.SetBool("jump", true);

        }
        else
        {
            animator.SetBool("jump", false);
        }

        if (Input.GetMouseButtonDown(0) && cnt > 0)
        {
            shieldgene();
            cnt -= 1;
        }

        //落下
        if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            this.rigid2D.AddForce(transform.up * this.downForce);
        }

        //HPをチェックし、0なら画面遷移
        if(director.GetComponent<GameDirector>().CheckHp())
        {
            SceneManager.LoadScene("FailureScene");
        }

        if(transform.position.y < -6)
        {
            SceneManager.LoadScene("FailureScene");
        }

        Playerpos = new Vector3(-7, transform.position.y, 0);

        this.Cnt.GetComponent<TextMeshProUGUI>().text =
            this.cnt.ToString("F0");

    }

    void shieldgene()
    {
        GameObject shield = Instantiate(baria_prefab);
        shield.transform.position = Playerpos;
    }
}
