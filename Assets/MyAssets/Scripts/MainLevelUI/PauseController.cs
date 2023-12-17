using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Button mute;
    [SerializeField] private Button exit;
    [SerializeField] private GameObject Pausetab;
    public Color selected;
    public Color notselected;
    private bool ismute = false;
    private bool isPaused = false;
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        mute.onClick.AddListener(MuteMusic);
        exit.onClick.AddListener(ExitToLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MuteMusic()
    {
        if (ismute == false)
        {
            SoundManager.Instance.Playbg(SoundManager.Sound.null1);
            mute.image.color= selected;
            Debug.Log("Muted");
            ismute = true;
        }
        else if (ismute == true)
        {
            SoundManager.Instance.Playbg(SoundManager.Sound.bgMusic);
            mute.image.color= notselected;
            Debug.Log("unMuted");
            ismute = false;
        }
        SoundManager.Instance.PlaySfx(SoundManager.Sound.buttonClick);
    }

    public void PauseGame()
    {
        if (isPaused == false)
        {
            Pausetab.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        else if (isPaused == true)
        {
            Pausetab.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
        SoundManager.Instance.PlaySfx(SoundManager.Sound.buttonClick);
    }
    void ExitToLevel()
    {
        SceneManager.LoadScene(0);
        SoundManager.Instance.PlaySfx(SoundManager.Sound.buttonClick);
    }
}
