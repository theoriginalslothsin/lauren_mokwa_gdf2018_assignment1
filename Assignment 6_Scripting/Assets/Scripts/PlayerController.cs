using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text specialcountText;
    public Text totalscoreText;
    public Text winText;



    private Rigidbody2D rb2d;
    private int count;
    private int specialcount;
    private int totalscore;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        specialcount = 0;
        totalscore = 0;
        winText.text = "";
        SetCountText ();
        SetSpecialCountText();
        SetTotalScoreText();
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
            SetTotalScoreText();
        }

        if (other.gameObject.CompareTag("SpecStar")) 
        {
            other.gameObject.SetActive(false);
            specialcount = specialcount + 5;
            SetSpecialCountText();
            SetTotalScoreText();
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

    void SetTotalScoreText()
    {
        totalscoreText.text = "Total Score: " + (count + specialcount);

        if (count >= 14 && specialcount >= 30)
        {
            winText.text = "You Win!!";
        }
    }
}
