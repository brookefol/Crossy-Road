using UnityEngine;
using System.Collections;

public class GameOverUI : MonoBehaviour
{
     public GameObject loseTextPrefab;
     private GameObject loseTextInstance;
    
    private void OnEnable()
    {
        //subsribed to GameOver and Game Reset
        GameEvents.OnGameOver += ShowLoseText;
        GameEvents.OnGameReset += HideLoseText;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= ShowLoseText;
        GameEvents.OnGameReset -= HideLoseText;
    }

    private void ShowLoseText()
    {
         if (loseTextInstance == null)
    {
        loseTextInstance = Instantiate(loseTextPrefab, transform);
        loseTextInstance.transform.localPosition = Vector3.zero;
    }

    }

    private void HideLoseText()
    {
        if (loseTextInstance != null)
        {
            Destroy(loseTextInstance);
            loseTextInstance = null;
        }
    }


}
