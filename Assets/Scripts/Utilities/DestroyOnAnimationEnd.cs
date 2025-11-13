using UnityEngine;

public class DestroyOnAnimationEnd : MonoBehaviour
{
    public float destroyDelay = 0.1f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + destroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
