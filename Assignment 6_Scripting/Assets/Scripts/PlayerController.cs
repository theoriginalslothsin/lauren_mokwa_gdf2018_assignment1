using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text specialcountText;
    public Text winText;



    private Rigidbody2D rb2d;
    private int count;
    private int specialcount;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        specialcount = 0;
        winText.text = "";
        SetCountText ();
        SetSpecialCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed); 
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("SpecStar")) 
        {
            other.gameObject.SetActive(false);
            specialcount = specialcount + 5;
            SetSpecialCountText();
        }
    }
        
        
    void SetCountText()
    {
        countText.text = "Star Count: " + count.ToString ();
    }

    void SetSpecialCountText()
    {
        specialcountText.text = "Special Star Count: " + specialcount.ToString ();
    }
}
