using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGamePlay : MonoBehaviour
{
    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }


}
