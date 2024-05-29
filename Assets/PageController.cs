using UnityEngine;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowPage1()
    {
        animator.Play("Page1_Transition");
    }

    public void ShowPage2()
    {
        animator.Play("Page2_Transition");
    }

    public void ShowPage3()
    {
        animator.Play("Page3_Transition");
    }
}
