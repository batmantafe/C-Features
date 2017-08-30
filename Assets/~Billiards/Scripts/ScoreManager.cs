using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text countText;
    private int count;

    // Use this for initialization
    void Start ()
    {
        count = 0;
        SetCountText();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            // Destroy(gameObject);

            count = count + 1;
            SetCountText(); // don't forget to attach the Canvas to this

            // count = count + 1; // to increase Count by 1 when each Pickup is collided with and deactivated
            // SetCountText(); // countText.text = "Count: " + count.ToString(); // update Text property every time we Pickup
        }

    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();

    }

}
