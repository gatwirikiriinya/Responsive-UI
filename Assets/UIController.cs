using UnityEngine;

public class UIController : MonoBehaviour
{
    public Animator animator;

    public void GoToPage2()
    {
        animator.SetTrigger("GoToPage2");
    }

    public void GoToPage3()
    {
        animator.SetTrigger("GoToPage3");
    }

    public void GoToPage1()
    {
        animator.SetTrigger("GoToPage1");
    }

    public void GoToPage2From3()
    {
        animator.SetTrigger("GoToPage2From3");
    }
    public void GoToPage1From2()
    {
        animator.SetTrigger("GoToPage1From2");
    }
}
