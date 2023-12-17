using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button Restart;
    [SerializeField] private Button exit;
    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        Restart.onClick.AddListener(RestartLevel);
        exit.onClick.AddListener(ExitToLevel);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.Instance.PlaySfx(SoundManager.Sound.buttonClick);
        SoundManager.Instance.Playbg(SoundManager.Sound.bgMusic);
    }
    void ExitToLevel()
    {
        SceneManager.LoadScene(0);
        SoundManager.Instance.PlaySfx(SoundManager.Sound.buttonClick);
    }
}
