using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
  private int score;
  TMP_Text scoreText;
  // Start is called before the first frame update
  void Start()
  {
    scoreText = GetComponent<TMP_Text>();
    scoreText.text = "000000000";
    score = 0;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void UpdateScore(int amountToIncrease)
  {
    score += amountToIncrease;
    scoreText.text = FormatScore();
  }

  public int GetScore()
  {
    return score;
  }

  private string FormatScore()
  {
    string strScore = score.ToString();
    int maxStrLength = 9;
    int remainingStrLength = maxStrLength - strScore.Length;
    string preceedingZeros = new string('0', remainingStrLength);
    // Debug.Log(preceedingZeros + strScore);
    return preceedingZeros + strScore;
  }
}
