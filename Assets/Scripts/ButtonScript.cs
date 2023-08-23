using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    private Image currentImg;
    [SerializeField] public Sprite MusicOn;
    [SerializeField] public Sprite MusicOff;

    private void Awake() {
        currentImg = GameObject.FindGameObjectWithTag("musicbutton").GetComponent<Image>();
    }
    public void onClickStart() {
        SceneManagement.Instance.LoadNextScene(SceneManagement.Scene.Level1);
        }

    public void onClickMusic() {
        if (currentImg.sprite == MusicOn) {
            AudioManager.Instance.MuteAll();
            currentImg.sprite = MusicOff;
        }
        else {
            currentImg.sprite = MusicOn;
            AudioManager.Instance.UnMuteAll();
        }
    }
}
