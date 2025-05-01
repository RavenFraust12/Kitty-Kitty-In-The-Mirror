using System.Collections;
using UnityEngine;

public class StarRequirement : MonoBehaviour
{
    public string levelName;
    public int starsAcquired = 0;
    public GameObject[] starsObject;

    public GameObject[] starsObtainedInGame; //In Game

    public void FinishLevel()
    {
        int stars = PlayerPrefs.GetInt(levelName, 0);
        if (starsAcquired > stars)
        {
            PlayerPrefs.SetInt(levelName, starsAcquired);
            Debug.Log($"{levelName} has {starsAcquired} stars");
        }

        for(int i = 0; i < starsAcquired; i++)
        {
            DelayShow(starsObtainedInGame,i);
        }
    }

    public void DelayShow(GameObject[] starObject, int i)
    {
        float transitionProgress = 0;
        float endProgress = 1f;
        while(transitionProgress < endProgress) 
        {
            transitionProgress += Time.deltaTime;
            starObject[i].SetActive(true);
            float starSize = transitionProgress / endProgress;
            starObject[i].GetComponent<RectTransform>().localScale = new Vector3(starSize,starSize,starSize);
        }
    }

    public void ShowAcquiredStars()//For Main Menu
    {
        int stars = PlayerPrefs.GetInt(levelName, 0);
        for (int i = 0; i < stars; i++)
        {
            starsObject[i].SetActive(true);
            Debug.Log($"{levelName} has {stars} stars!");
        }
    }
}
