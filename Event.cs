using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene(0); // Assuming MainMenu is the first scene in the build settings
    }

    public void ChangeToGameplay()
    {
        SceneManager.LoadScene(1); // Assuming Gameplay is the second scene in the build settings
    }

}
