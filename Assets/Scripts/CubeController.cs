using UnityEngine;

public class CubeController : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }
    private void Awake()
    {
        Debug.Log("Awake");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
