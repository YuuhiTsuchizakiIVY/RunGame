using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float dropSpeed = -0.1f;
    public AudioClip damage_se;
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(this.dropSpeed, 0, 0);

        if(transform.position.x < -15.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject director = GameObject.Find("GameDirector");
        if (collision.gameObject.tag == "Player")
        {
            director.GetComponent<GameDirector>().DecreaseHp();
        }
        Debug.Log("“–‚½‚è");
        Destroy(gameObject);
        this.aud.PlayOneShot(this.damage_se);
    }
}
