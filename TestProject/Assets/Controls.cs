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
        float s = 5f;

        power -= 0.025f * Time.deltaTime;
        if (power < 0.05f)
            s = 1f;
        if (Vector3.Distance(transform.position, GameObject.Find("charger").transform.position) < 6)
            power += 0.1f * Time.deltaTime;

        // movement
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0.1f)
            {
                s *= 2f;
                stamina -= 0.25f * Time.deltaTime;
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
            transform.position += transform.forward * s * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position += -transform.forward * s * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * s * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            transform.position += -transform.right * s * Time.deltaTime;

        // jump
        if (Physics.Raycast(transform.position, Vector3.down, 1.5f))
            LastFloored = transform.position;

        if (Input.GetKeyDown(KeyCode.Space) && Vector3.Distance(transform.position, LastFloored) < 1f)
            GetComponent<Rigidbody>().AddForce(Vector3.up * 8, ForceMode.Impulse);

        // body
        if (Input.GetAxis("Mouse X") > 0)
            transform.Rotate(0, (600 * Mathf.Abs(Input.GetAxis("Mouse X")) * Time.deltaTime), 0);
        if (Input.GetAxis("Mouse X") < 0)
            transform.Rotate(0, -(600 * Mathf.Abs(Input.GetAxis("Mouse X")) * Time.deltaTime), 0);


        // cam
        Transform cam = transform.Find("Main Camera");

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
