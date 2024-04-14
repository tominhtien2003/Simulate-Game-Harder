using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesTransition : MonoBehaviour
{
    private Image image;
    private Animator animator;
    private void Awake()
    {
        image = GetComponentInChildren<Image>();
        animator = GetComponent<Animator>();
    }
    public void ResetLevel()
    {
        StartCoroutine(IEResetLevel());
    }
    public void LoadLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            return;
        }
        StartCoroutine(IELoadLevel());
    }
    private IEnumerator IELoadLevel()
    {
        animator.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        animator.SetTrigger("Start");
    }
    private IEnumerator IEResetLevel()
    {
        animator.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        animator.SetTrigger("Start");
    }
}
