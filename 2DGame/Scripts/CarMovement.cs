using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CarMovement : MonoBehaviour
{
    public float speed=10;
    private int pkgPick = 0;
    private int pkgdeliver = 0;
    [SerializeField] float turnspeed = 200;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float steerspeed = Input.GetAxis("Horizontal");
        float movespeed = Input.GetAxis("Vertical");
        /*Debug.Log("Steer Speed: " + steerspeed);
        Debug.Log("Move Speed: " + movespeed);
        Debug.Log("Time"+ Time.deltaTime);*/
        transform.Translate(0, movespeed * speed * Time.deltaTime, 0);
        transform.Rotate(0, 0,-1* steerspeed  * Time.deltaTime* turnspeed);

        GameObject speedtext = GameObject.FindWithTag("speed");
        TextMeshProUGUI textComponent = speedtext.GetComponent<TextMeshProUGUI>();
        textComponent.text = "Speed : "+speed+ "\nPackage: " + pkgdeliver;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pkg" && pkgPick==0)
        {
            
            // Deactivate the GameObject
            spriteRenderer.color = Color.red;
            collision.gameObject.SetActive(false);
            pkgPick = 1;
        }
        //Debug.Log(spriteRenderer.color.ToString());
        if (collision.gameObject.tag =="customer" && pkgPick==1)
        {
            Debug.Log("Inside Customer");
            // Deactivate the GameObject
            spriteRenderer.color = Color.blue;
            //customer.SetActive(false);
            pkgdeliver += 1;
            pkgPick = 0;
        }
        if(collision.gameObject.tag == "speedup")
        {
            
            speed += 2;
            Debug.Log("Fast Speed: " + speed);
        }
        if (collision.gameObject.tag == "speeddown")
        {
            
            speed -= 1;
            Debug.Log("Speed Down: " + speed);
        }
    }

}
