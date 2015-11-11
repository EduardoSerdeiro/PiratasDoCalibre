using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScoreList : MonoBehaviour {


    ScoreboardManager scoreManager;

    [SerializeField] private GameObject playerScoreList;

    private int lastChangeCount;
	void Start () {

        scoreManager = GameObject.FindObjectOfType<ScoreboardManager>();

       // lastChangeCount = scoreManager.GetChangeCounter();

        if (scoreManager == null)
        {
            Debug.Log("ERROR: Adicione o ScoreManager a um gameobject");
            return;
        }
       
	}
	
	// Update is called once per frame
	void Update () {

        if (scoreManager.GetChangeCounter() == lastChangeCount)
        {
            return;

        }
        lastChangeCount = scoreManager.GetChangeCounter();
       
            while (this.transform.childCount > 0)
            {
                Transform c = this.transform.GetChild(0);
                c.SetParent(null);
                Destroy(c.gameObject);
            }

            string[] names = scoreManager.GetPlayerNames();

            foreach (string name in names)
            {
                GameObject go = (GameObject)Instantiate(playerScoreList);
                go.transform.SetParent(this.transform);
                go.transform.Find("Username").GetComponent<Text>().text = name;
                go.transform.Find("Kills").GetComponent<Text>().text = scoreManager.GetScore(name, "Kills").ToString();
                go.transform.Find("Deaths").GetComponent<Text>().text = scoreManager.GetScore(name, "Deaths").ToString();
                go.transform.Find("Gold").GetComponent<Text>().text = scoreManager.GetScore(name, "Gold").ToString();

            }
       
	}
}
