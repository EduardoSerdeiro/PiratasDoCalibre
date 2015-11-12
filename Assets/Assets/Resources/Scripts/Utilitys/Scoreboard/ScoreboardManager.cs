using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScoreboardManager : MonoBehaviour {


    Dictionary<string, Dictionary<string, int>> playerScores;

    private int changeCounter = 0;

	void Start () {

        SetScore("Dudu", "Kills", 9);
        SetScore("Dudu", "Deaths", 10);
        SetScore("Dudu", "Gold", 100);
        SetScore("Samurai", "Kills", 80);
        SetScore("BR", "Kills", 5);
        SetScore("BR", "Deaths", 15);

	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ADD_KILL();
        }
    }

   private void Init()
    {
        if (playerScores != null)
            return;

        playerScores = new Dictionary<string,Dictionary<string,int>>();
    }

    public int GetScore(string userName, string scoreType)
    {
        Init();

        if (playerScores.ContainsKey(userName) == false)
        {
            return 0;
        }

        if(playerScores[userName].ContainsKey(scoreType) == false)
        {
            return 0;
        }

        return playerScores[userName][scoreType];
    }

    public void SetScore(string userName, string scoreType, int value)
    {
        Init();

        changeCounter++;

            if (playerScores.ContainsKey(userName) == false)
            {
                playerScores[userName] = new Dictionary<string, int>();
            }
      

            playerScores[userName][scoreType] = value;
       
    }

    public void ChangeScore(string userName, string scoreType, int amount)
    {
        Init();
        int curScore = GetScore(userName, scoreType);
        SetScore(userName, scoreType, curScore + amount);

    }
	
    public string[] GetPlayerNames()
    {
        Init();
        return playerScores.Keys.ToArray();
    }

    //public string[] GetPlayerNames(string sortingScoreType)
    //{
    //    Init();
    //    string[] names = playerScores.Keys.ToArray();
    //    return playerScores.Keys.OrderBy( names >= GetScore(names, sortingScoreType).ToArray();
    //}
    public int GetChangeCounter()
    {
        return changeCounter;
    }

    public void ADD_KILL()
    {
        ChangeScore("Dudu", "Kills", 1);
    }


   
}
