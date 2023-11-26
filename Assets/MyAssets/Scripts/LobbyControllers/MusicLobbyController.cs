using UnityEngine;
using UnityEngine.UI;

public class MusicLobbyController : MonoBehaviour
{
    [SerializeField] Button MusicMute;
    [SerializeField] Button goBack;
    [SerializeField] Color notselected;
    [SerializeField] Color selected;
    private bool muted=false;
    // Start is called before the first frame update
    void Start()
    {
        goBack.onClick.AddListener(GoBack);
        MusicMute.onClick.AddListener(MuteMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GoBack() { gameObject.SetActive(false);
        SoundManager.Instance.PlaySfx(SoundManager.Sound.buttonClick);
    }
    void MuteMusic()
    {
        if (muted == false)
        {
            SoundManager.Instance.Playbg(SoundManager.Sound.null1);
            MusicMute.image.color= selected;
            
            muted = true;
        }
        else if(muted==true)
        {
            SoundManager.Instance.Playbg(SoundManager.Sound.bgMusic);
            MusicMute.image.color= selected;
            muted = false;
        }

    }
}
