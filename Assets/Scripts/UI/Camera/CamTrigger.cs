using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public Vector3 newCamPos, newPlayerPos;
    CamController camCont;
    GameObject player;
    GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        camCont = Camera.main.GetComponent<CamController>();   
        player = GameObject.FindGameObjectWithTag("Player");
        wall = GameObject.FindGameObjectWithTag("MoveWall");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            camCont.minPos += newCamPos;
            camCont.maxPos += newCamPos;

            wall.transform.position += newCamPos;

            collision.GetComponent<HeroBehaviour>().spawnPoint.position = newPlayerPos;
            collision.GetComponent<HeroBehaviour>().Spawn(0);
            player.transform.position = new Vector3(newPlayerPos.x + 2, newPlayerPos.y, newPlayerPos.z);
            player.transform.rotation = new Quaternion(0, 0, 0.7f, 0.7f);
        }
    }
}
