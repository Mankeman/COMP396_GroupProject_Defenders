using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Mainmenu : MonoBehaviour
{
    private int instructionsArrayLocation = 0;
    [TextAreaAttribute(10,20)]
    public string[] instructionsTextArray;
    public Text instructionsText;
    private void Start()
    {
        Time.timeScale = 1f;
        instructionsText.text = instructionsTextArray[0].ToString();
    }
    public void LOAD_SCENE(string SceneName)
    {

        SceneManager.LoadScene(SceneName);

    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void EasyMode()
    {
        PlayerPrefs.SetString("Difficulty", "Easy");
    }
    public void MediumMode()
    {
        PlayerPrefs.SetString("Difficulty", "Medium");
    }
    public void HardMode()
    {
        PlayerPrefs.SetString("Difficulty", "Hard");
    }
    public void SwapText()
    {
        instructionsArrayLocation++;
        if(instructionsArrayLocation >= instructionsTextArray.Length)
        {
            instructionsArrayLocation = 0;
        }
        instructionsText.text = instructionsTextArray[instructionsArrayLocation].ToString();
    }
}
