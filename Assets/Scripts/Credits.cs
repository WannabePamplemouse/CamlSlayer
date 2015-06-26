using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour
{

    public GameObject camera;
    public int speed = 1;
    public int timeBeforeMenu = 10;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("Menu");
        }

        camera.transform.Translate(Vector3.down * Time.deltaTime * speed);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeBeforeMenu);
        Application.LoadLevel("Menu");
    }
}
