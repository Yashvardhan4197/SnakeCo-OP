using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerController playerController;
    [SerializeField] int pNumber;
    bool shieldactive = false;
    
    private IEnumerator ShieldPlayer()
    {
            Debug.Log("ShieldActivated");
            shieldactive = true;
            playerController.ShieldUICallfromTrigger(pNumber,shieldactive);
    
            yield return new WaitForSeconds(3f);
            shieldactive = false;
            playerController.ShieldUICallfromTrigger(pNumber,shieldactive);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MassReducer")
        {
            playerController.ReducePlayer(pNumber);
            SoundManager.Instance.PlaySfx(SoundManager.Sound.SnakeEat);
        }
        if (collision.tag == "MassGainer")
        {
            playerController.GrowPlayer(pNumber);
            SoundManager.Instance.PlaySfx(SoundManager.Sound.SnakeEat);
        }
        if (collision.tag == "Shield")
        {

            StartCoroutine(ShieldPlayer());
            SoundManager.Instance.PlaySfx(SoundManager.Sound.SnakeEat);
        }

        if (collision.tag == "PlayerTail")
        {
            if (shieldactive == false)
            {
                Debug.Log("GameOver");
                Time.timeScale = 0;
                //playerController.GameOverController.SetActive(true);
                playerController.GameOver();
                playerController.isDead(true);
                SoundManager.Instance.PlaySfx(SoundManager.Sound.Snakedeath);
            }
        }
        if(collision.tag == "Multiplier")
        {
            playerController.PointsMultiplier(pNumber);
            SoundManager.Instance.PlaySfx(SoundManager.Sound.SnakeEat);
        }
    }
}
