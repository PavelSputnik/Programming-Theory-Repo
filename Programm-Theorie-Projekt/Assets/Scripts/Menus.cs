using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

    public GameObject startMenu, optionsMenu, levelMenu;
    public Slider audioSlider, difficultySlider;
    public AudioSource music;
    public static float ballSpeed;
    public Text[] bestzeit;
    private float bestzeitnum;
    private float min;
    private float sec;
    public Button[] level;
    

    void Start ()
    {
        audioSlider = audioSlider.GetComponent<Slider>();
        difficultySlider = difficultySlider.GetComponent<Slider>();
        music = music.GetComponent<AudioSource>();
        audioSlider.value = music.volume;
        difficultySlider.value = 2 ;
        ballSpeed = 20;
        
       
          for (var i = 0; i < 10; i++)
            {
                if (PlayerPrefs.HasKey("Bestzeit" + (i + 3)))
                {
                    bestzeitnum = PlayerPrefs.GetFloat("Bestzeit" + (i + 3));
                    min = Mathf.Ceil(bestzeitnum / 60 - 1);
                    sec = Mathf.Ceil(bestzeitnum % 60);
                    bestzeit[i].text = string.Format("{0:00}:{1:00}", min, sec);
                }
                else
                {
                    bestzeit[i].text = "--";
                    if (!PlayerPrefs.HasKey("Bestzeit" + (i + 2)))
                        level[i].interactable = false;

                }
            }
    }

    void Update ()
    {
        music.volume = audioSlider.value;
        DifficultyLevels();
	}
    
    public void StartButton (int level)
    {
        SceneManager.LoadScene(level+2);
    }

    public void OptionsButton ()
    {
        startMenu.SetActive (false);
        optionsMenu.SetActive (true);
    }

    public void ExitButton ()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ReturnButton ()
    {
        startMenu.SetActive (true);
        optionsMenu.SetActive (false);
        levelMenu.SetActive (false);
    }

    public void LevelSelect ()
    {
        levelMenu.SetActive (true);
        startMenu.SetActive (false);

        
    }

    void DifficultyLevels ()
    {
        if (difficultySlider.value == 1)
            ballSpeed = 10;

        if (difficultySlider.value == 2)
            ballSpeed = 20;

        if (difficultySlider.value == 3)
            ballSpeed = 30;

    }
   
}
