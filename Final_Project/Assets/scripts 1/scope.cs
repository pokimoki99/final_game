using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scope : MonoBehaviour
{
    public Animator animator;

    private bool isScoped=false;

    GameObject scopeOverlay;
    GameObject reticleOverlay;

    public void Awake()
    {
        scopeOverlay = GameObject.FindWithTag("scope");
        reticleOverlay = GameObject.FindWithTag("reticle");
        scopeOverlay.SetActive(!true);

    }

    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("isScoped", isScoped);

            if (isScoped)
                StartCoroutine(onScoped());
            else
                OnUnscoped();

        }
    }
    void OnUnscoped()
    {
        scopeOverlay.SetActive(!true);
        reticleOverlay.SetActive(true);

    }
    IEnumerator onScoped()
    {
        yield return new WaitForSeconds(0.15f);

        scopeOverlay.SetActive(true);
        reticleOverlay.SetActive(!true);


    }
}
