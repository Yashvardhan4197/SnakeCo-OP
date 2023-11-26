
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Button startbutton;
    [SerializeField] Button musicbutton;
    [SerializeField] Button exitbutton;
    [SerializeField] GameObject chooseLevel;
    [SerializeField] GameObject MusicLobby;
    // Start is called before the first frame update
    void Start()
    {
        chooseLevel.SetActive(false);
        MusicLobby.SetActive(false);
        startbutton.onClick.AddListener(StartCanvas);
        musicbutton.onClick.AddListener(MusicCanvas);
        exitbutton.onClick.AddListener(ExitLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartCanvas(){
        chooseLevel.SetActive(true);
        SoundManager.Instance.PlaySfx(SoundManager.Sound.buttonClick);
    }
    void MusicCanvas(){
        MusicLobby.SetActive(true);
        SoundManager.Instance.PlaySfx(SoundManager.Sound.buttonClick);
    }
    void ExitLevel(){
        SoundManager.Instance.PlaySfx(SoundManager.Sound.buttonClick);
        Application.Quit();
    }
}
