using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Button mute;
    [SerializeField] private Button exit;
    public Color selected;
    public Color notselected;
    private bool ismute = false;
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
    }

    void ExitToLevel()
    {
        SceneManager.LoadScene(0);
    }
}
