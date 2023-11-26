using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseLevelController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button onePlayer;
    [SerializeField] Button twoPlayer;
    [SerializeField] Button goBack;
    void Start()
    {
        goBack.onClick.AddListener(GoBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GoBack()
    {
        gameObject.SetActive(false);
        SoundManager.Instance.PlaySfx(SoundManager.Sound.buttonClick);
    }
}
