using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void onClickStart() {
        SceneManagement.Instance.LoadNextScene(SceneManagement.Scene.Level1);
    }
}
