using UnityEngine;

public class SnakeLobbyController : MonoBehaviour
    
{
    private Animator animator;
    private new RectTransform transform;
    
    // Start is called before the first frame update
    void Awake()
    {
        animator=GetComponent<Animator>();
        transform=GetComponent<RectTransform>();
        //animator.SetFloat("posX",transform.anchoredPosition.y);
        if(transform.anchoredPosition.y>0){
            animator.Play("Mirrored");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
