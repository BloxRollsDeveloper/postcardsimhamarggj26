using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIController : MonoBehaviour
{
    private GameObject destination;
    private NavMeshAgent agent;
    private Animator animator;
    
    [Header("Mask UI")]
    public GameObject maskCanvasPrefab;
    private GameObject activeMaskCanvas;
    void Start()
    {
        destination = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        agent.SetDestination(destination.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if  (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Touched the player");
            SceneManager.LoadScene("GameOver");
        }
    }

    public void IncreaseSpeed(float amount)
    {
        agent.speed += amount;
    }

    public void TriggerMaskEffect()
    {
        StartCoroutine(StopMovement());
    }
    
    public IEnumerator StopMovement()
    {
        agent.isStopped = true;
        animator.SetBool("isStanding", true);

        if (maskCanvasPrefab != null)
        {
            activeMaskCanvas = Instantiate(maskCanvasPrefab);
            CanvasGroup canvasGroup = activeMaskCanvas.GetComponent<CanvasGroup>();
            yield return StartCoroutine(FadeCanvas(canvasGroup, 0f, 1f, 0.2f));
        }
        
        yield return new WaitForSeconds(6f);

        if (activeMaskCanvas != null)
        {
            CanvasGroup canvasGroup = activeMaskCanvas.GetComponent<CanvasGroup>();
            yield return StartCoroutine(FadeCanvas(canvasGroup, 1f, 0f, 0.5f));
            Destroy(activeMaskCanvas);
        }
        agent.isStopped = false;
        animator.SetBool("isStanding", false);
    }

    private IEnumerator FadeCanvas(CanvasGroup canvasGroup, float from, float to, float duration)
    {
        float t = 0f;
        canvasGroup.alpha = from;

        while (t < duration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(from, to, t / duration);
            yield return null;
        }
        canvasGroup.alpha = to;
    }
}