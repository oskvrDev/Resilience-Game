using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExtraPlayers : MonoBehaviour
{
    // Start is called before the first frame update
    public void Multiplayer(string temp_name)
    {
        SceneManager.LoadScene(temp_name);
    }
}
