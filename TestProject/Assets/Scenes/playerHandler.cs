using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHandler : MonoBehaviour
{
    // public Rigidbody rb;
    public static float speed = 0.04f;
    // Start is called before the first frame update
    // void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    // }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * 4;
        float y = Input.GetAxis("Mouse Y") * 4;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject created = Instantiate(Resources.Load<GameObject>("bullet"), transform.position, Quaternion.identity);
            created.GetComponent<Projectile>().dir = transform.up;
        }


        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.up * -(speed / 2));
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                transform.Find("TrailNormal").gameObject.SetActive(true);
                transform.Find("TrailFast").gameObject.SetActive(false);
                StartCoroutine(LowFov());

                transform.Translate(Vector3.up * speed);
            }
            else
            {
                transform.Find("TrailNormal").gameObject.SetActive(false);
                transform.Find("TrailFast").gameObject.SetActive(true);
                StartCoroutine(HighFov());

                transform.Translate(Vector3.up * speed * 4);
            }

            

        }
        else
        {
            transform.Find("TrailNormal").gameObject.SetActive(true);
            transform.Find("TrailFast").gameObject.SetActive(false);
            StartCoroutine(LowFov());
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * (speed / 1.5f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * (speed / 1.5f));
        }


        if (x < 0)
        {
            transform.Rotate(0,0,speed*10*(x-x*2));
        }
        if(x > 0)
        {
            transform.Rotate(0,0,-speed*10*x);
        }


        if(y>0)
        {
            transform.Rotate(-speed*10*(y),0,0, Space.Self);
        }
        if(y<0)
        {
            transform.Rotate(speed*10*((y-y*2)),0,0, Space.Self);
        }
    }

    IEnumerator HighFov()
    {
        if (transform.Find("Main Camera").GetComponent<Camera>().fieldOfView == 90)
        {
            for (int i = 0; i < 20; i++)
            {
                transform.Find("Main Camera").GetComponent<Camera>().fieldOfView += 1;
                yield return new WaitForSeconds(0.005f);
            }
        }
    }
    IEnumerator LowFov()
    {
        if (transform.Find("Main Camera").GetComponent<Camera>().fieldOfView == 110)
        {
            for (int i = 0; i < 20; i++)
            {
                transform.Find("Main Camera").GetComponent<Camera>().fieldOfView -= 1;
                yield return new WaitForSeconds(0.005f);
            }
        }
    }
}