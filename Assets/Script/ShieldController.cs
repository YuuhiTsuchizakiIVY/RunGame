using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    GameObject player;
    float time = 0f;
    float time2 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        time += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(
            playerPos.x, playerPos.y, transform.position.z);
        time2 += Time.deltaTime;
        if(time + 0.5f <= time2){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.gameObject.tag == "meteor")
        {
            Destroy(gameObject);
        }*/
    }
}
