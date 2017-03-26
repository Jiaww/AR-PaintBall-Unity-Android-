using UnityEngine;
using System.Collections.Generic;
using Photon;
using UnityEngine.UI;

public class BoardBehavior : Photon.MonoBehaviour {

    public GameObject SplatterPrefab;
	public Text scoreText;
	private float score;
    private List<GameObject> splatters = new List<GameObject>();

	private float distance;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter(Collision collision)
    {
       
        var other = collision.collider.gameObject;
        Vector3 hit_position = other.transform.position;
        if (other.CompareTag("Ball"))
        {
            PhotonNetwork.Destroy(other);
            Quaternion rot =  Quaternion.AngleAxis(Random.Range(0f, 360f), new Vector3(0, 0, 1)) ; //*transform.rotation;
            var splatter = Instantiate(SplatterPrefab, hit_position, rot) as GameObject;

            splatter.GetComponent<Renderer>().material.color = other.GetComponent<Renderer>().material.color;

            splatters.Add(splatter);
			//compute the score:
			distance = hit_position.x * hit_position.x + (hit_position.y - 5.0f)*(hit_position.y - 5.0f);
			distance = 	Mathf.Sqrt (distance);
			if (distance < 5.0f) {
				score += 50;
			} else if (distance < 10.0f) {
				score += 40;
			} else if (distance < 15.0f) {
				score += 30;
			} else if (distance < 20.0f) {
				score += 20;
			} else {
				score += 10;
			}
			scoreText.text = "Score: " + score;
        }

    }
}
