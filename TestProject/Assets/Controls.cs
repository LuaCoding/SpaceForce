using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    float stamina
    {
        get
        {
            return _stamina;
        }
        set
        {
            if (value > 1f)
                value = 1f;
            if (value < 0f)
                value = 0f;

            GameObject.Find("HUD").transform.Find("Stamina").Find("Slider").GetComponent<UnityEngine.UI.Slider>().value = value;

            _stamina = value;
        }
    }
    float _stamina = 1f;

    float power
    {
        get
        {
            return _power;
        }
        set
        {
            if (value > 1f)
                value = 1f;
            if (value < 0f)
                value = 0f;

            GameObject.Find("HUD").transform.Find("Power").Find("Slider").GetComponent<UnityEngine.UI.Slider>().value = value;

            _power = value;
        }
    }
    float _power = 1f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    Vector3 LastFloored;

    float amount = 0;

    
    Coroutine regen;

    void Update()
    {
        // speed
        float s = 5f;
        //float s = 500f;

        // battery left & charge
        power -= 0.010f * Time.deltaTime;
        if (power < 0.05f)
            s = 1f;


        bool nextToCharger = false;
        foreach(GameObject c in GameObject.FindObjectsOfType<GameObject>())
        {
            if (c.name.StartsWith("charger") == false)
                continue;

            if (Vector3.Distance(transform.position, c.transform.position) < 6)
            {
                nextToCharger = true;
                if (Input.GetKey(KeyCode.R))
                {
                    power += 0.1f * Time.deltaTime;
                    c.GetComponent<Charger>().ChargeLeft -= 2.5f * Time.deltaTime;
                    GameObject.Find("HUD").transform.Find("ChargePrompt").Find("Left").GetComponent<TMPro.TMP_Text>().text = c.GetComponent<Charger>().ChargeLeft.ToString();
                }
            }
        }
        GameObject.Find("HUD").transform.Find("ChargePrompt").gameObject.SetActive(nextToCharger);
        

        // movement
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0.1f)
            {
                s *= 2f;
                stamina -= 0.05f * Time.deltaTime;
                if (regen == null == false)
                    StopCoroutine(regen);
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (regen == null == false)
                StopCoroutine(regen);
            regen = StartCoroutine(loop());
            IEnumerator loop()
            {
                yield return new WaitForSeconds(1f);
                while (stamina < 1f)
                {
                    yield return new WaitForSeconds(0.01f);
                    stamina += 0.005f;
                }
            }
        }



        Rigidbody rb = GetComponent<Rigidbody>();


        if (Input.GetKey(KeyCode.W))
            //rb.position += transform.forward * s * Time.deltaTime;
            rb.AddForce(transform.forward * s);
        if (Input.GetKey(KeyCode.S))
            //rb.position += -transform.forward * s * Time.deltaTime;
            rb.AddForce(-transform.forward * s);
        if (Input.GetKey(KeyCode.D))
            //rb.position += transform.right * s * Time.deltaTime;
            rb.AddForce(transform.right * s);
        if (Input.GetKey(KeyCode.A))
            //rb.position += -transform.right * s * Time.deltaTime;
            rb.AddForce(-transform.right * s);


        Transform cam = Camera.main.transform;

        // body
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.eulerAngles += new Vector3(0, (600 * Mathf.Abs(Input.GetAxis("Mouse X")) * Time.deltaTime), 0);
            //transform.Rotate(0, (600 * Mathf.Abs(Input.GetAxis("Mouse X")) * Time.deltaTime), 0);
            //cam.Rotate(0, (600 * Mathf.Abs(Input.GetAxis("Mouse X")) * Time.deltaTime), 0);
        }
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.eulerAngles += new Vector3(0, -(600 * Mathf.Abs(Input.GetAxis("Mouse X")) * Time.deltaTime), 0);
            //transform.Rotate(0, -(600 * Mathf.Abs(Input.GetAxis("Mouse X")) * Time.deltaTime), 0);
            //cam.Rotate(0, -(600 * Mathf.Abs(Input.GetAxis("Mouse X")) * Time.deltaTime), 0);
        }

        //if (transform.eulerAngles.x > 90)
        //  transform.eulerAngles -= new Vector3(1, 0, 0);
        //if (transform.eulerAngles.x < -90)
        //  transform.eulerAngles += new Vector3(1, 0, 0);

        //if (transform.eulerAngles.y > 90)
        //  transform.eulerAngles -= new Vector3(0, 1, 0);
        //if (transform.eulerAngles.y < -90)
        //  transform.eulerAngles += new Vector3(0, 1, 0);

        //if (transform.eulerAngles.z > 90)
        //  transform.eulerAngles -= new Vector3(0, 0, 1);
        //if (transform.eulerAngles.z < -90)
        //transform.eulerAngles += new Vector3(0, 0, 1);

        RaycastHit hit;
        Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit, 10f);

        Debug.DrawLine(hit.point, hit.point + hit.normal * 3, Color.red);


        Vector3 current = transform.Find("model").rotation.eulerAngles;
        Quaternion target = Quaternion.LookRotation(-transform.forward, hit.normal);
        Vector3 next = new Vector3();

        /*
        if (target.x < current.x)
            next.x = current.x - (current.x - target.x) / 2f;
        if (target.x > current.x)
            next.x = current.x + (target.x - current.x) / 2f;
        */
        if (target.y < current.y)
            next.y = current.y - (current.y - target.y) / 2f;
        if (target.y > current.y)
            next.y = current.y + (target.y - current.y) / 2f;

        if (target.z < current.z)
            next.z = current.z - (current.z - target.z) / 2f;
        if (target.z > current.z)
            next.z = current.z + (target.z - current.z) / 2f;

        
        transform.Find("model").rotation = Quaternion.RotateTowards(transform.Find("model").rotation, target, 1f);


        // cam

        if (Input.GetAxis("Mouse Y") < 0)
        {
            cam.Rotate((600 * Mathf.Abs(Input.GetAxis("Mouse Y")) * Time.deltaTime), 0, 0);
            amount += (600 * Mathf.Abs(Input.GetAxis("Mouse Y")) * Time.deltaTime);
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            cam.Rotate(-(600 * Mathf.Abs(Input.GetAxis("Mouse Y")) * Time.deltaTime), 0, 0);
            amount += -(600 * Mathf.Abs(Input.GetAxis("Mouse Y")) * Time.deltaTime);
        }

        if (amount > 30)
        {
            cam.Rotate(-(amount - 30), 0, 0);
            amount -= amount - 30;
        }
        if (amount < -30)
        {
            cam.Rotate(Mathf.Abs(amount) - 30, 0, 0);
            amount += Mathf.Abs(amount) - 30;
        }
    }
}
