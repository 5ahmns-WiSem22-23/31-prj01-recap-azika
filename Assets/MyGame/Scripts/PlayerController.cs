using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    [SerializeField]
    private Rigidbody2D rb;
    private GameObject Player;
    [SerializeField]
    private Text Potions;
    public bool collided1;
    public bool collided2;
    public bool collided3;
    public bool collided4;
    public GameObject potion2;
    public GameObject potion3;
    public GameObject potion4;
    private Transform tf;
    public float pushBackForce;
    

    private int potionAmount;


    void Start()
    {
        //potionanzahl am anfang des spieles
        potionAmount = 0;
    }

    void Update()
    {
        //movement player
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }


        transform.position = pos;

        //update potion UI
        Potions.text = "Potions: " + potionAmount;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when player mit erstem Pickup collided wird Ui +1, Zerstört Objekt,bool für nächstes Projekt true
        if (collision.GetComponent<Potion1>())
        {
            potionAmount++;
            Destroy(collision.gameObject);
            collided1 = true;
            Debug.Log("collided");
        }

        //wenn mit box collided wird counter -1 und nächstes Pickup wird aktiviert
        if (collision.GetComponent<DropHere>() && collided1 == true)
        {
            potionAmount--;
            this.potion2.SetActive(true);
            Debug.Log("collidedBox");
            collided1 = false;
        }

        if (collision.GetComponent<Potion2>())
        {
            potionAmount++;
            Destroy(collision.gameObject);
            collided2 = true;
            Debug.Log("collided");
        }

        if (collision.GetComponent<DropHere>() && collided2 == true)
        {
            potionAmount--;
            this.potion3.SetActive(true);
            Debug.Log("collidedBox");
            collided2 = false;
        }

        if (collision.GetComponent<Potion3>())
        {
            potionAmount++;
            Destroy(collision.gameObject);
            collided3 = true;
            Debug.Log("collided");
        }

        if (collision.GetComponent<DropHere>() && collided3 == true)
        {
            potionAmount--;
            this.potion4.SetActive(true);
            Debug.Log("collidedBox");
        }

        if (collision.GetComponent<Potion4>())
        {
            potionAmount++;
            Destroy(collision.gameObject);
            collided4 = true;
            Debug.Log("collided");
        }

        if (collision.GetComponent<DropHere>() && collided4 == true)
        {
            potionAmount--;
            SceneManager.LoadScene("Win");
        }

            if (collision.GetComponent<wall>())
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-10.2f, 0f, 5f);
            Debug.Log("walled");
        }


        // Prüfe, ob das kollidierende Objekt den richtigen Tag hat
        if (collision.CompareTag("Map"))
        {
            // Berechne die Richtung, in der das Objekt zurückgeschoben werden soll
            Vector3 pushDirection = transform.position - collision.gameObject.transform.position;

            // Füge dem kollidierenden Objekt eine Kraft hinzu, um es zurückzuschieben
            rb.AddForce(pushDirection.normalized * pushBackForce, ForceMode2D.Impulse);

            Debug.Log("hallo");
        }

        if (collision.GetComponent<SpeedArea1>())
        {

            speed = 50f;
            Debug.Log("collidedSpeed");
        }

    }
    }
    