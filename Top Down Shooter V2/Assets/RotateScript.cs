using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public Transform player;
    public Camera maincamera;
    public GameObject Gun;
    public GameObject bullet;

    //Maybe this method also for fixing coyote jump and buffer time
    public float timer;
    public float shootcooldown = 0.3f;
    public bool canshoot = true;

    public float fireforce;

    public FXManager fxmanager;

    private void Start()
    {
        fxmanager = FXManager.instance;
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 mousepos = maincamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dv = mousepos - transform.position;

        float angle = Mathf.Atan2(dv.y, dv.x) * Mathf.Rad2Deg;

        Quaternion turnangle = Quaternion.Euler(0, 0, angle);
        transform.rotation = turnangle;

        if (!canshoot)
        {
            timer += Time.deltaTime;
            if (timer >= shootcooldown)
            {
                canshoot = true;
                timer = 0;
            }
        }

        //Either left or right (mouse) can shoot, 0 left, 1 right

        if (Input.GetMouseButtonDown(0) && canshoot || Input.GetMouseButtonDown(1) && canshoot)
        {
            canshoot = false;
            Debug.Log("Ranjit Shot");
            GameObject newbullet = Instantiate(bullet, Gun.transform.position, Gun.transform.rotation);
            newbullet.GetComponent<Rigidbody2D>().AddForce(Gun.transform.up * fireforce, ForceMode2D.Impulse);

            Quaternion smokeangle = Quaternion.Euler(0, 0, angle - 90);
            fxmanager.PlayEffect(fxmanager.GunSmokeEffect, Gun.transform.position, smokeangle);
            //up relative to the objects sprite
        }


    }
}
