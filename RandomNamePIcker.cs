using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RandomNamePIcker : MonoBehaviour
{
    public TextMeshProUGUI nameText;
 //when hit play button,flash random name,when play the stop button stop on a random name
    // Start is called before the first frame update    
    private Coroutine flashCoroutine;
    public float flashInterval = 0.001f;

    private bool isFlashing = false;
    

    private void Start()
    {
        // Stop flashing when the scene starts
        StopFlashing();
    }

    private void Update()
    {
        
    }
    public void StartFlashing()
    {
        if (!isFlashing)
        {
            isFlashing = true;
            flashCoroutine = StartCoroutine(FlashRandomNameCoroutine());
        }
    }

    public void StopFlashing()
    {
        if (isFlashing)
        {
            isFlashing = false;
            if (flashCoroutine != null)
            {
                StopCoroutine(flashCoroutine);
            }
        }
    }

    private IEnumerator FlashRandomNameCoroutine()
    {
        while (true)
        {
            nameText.text = GetRandomName();
            yield return new WaitForSeconds(flashInterval);
        }
    }

    private string GetRandomName()
    {
        string[] names = { "John", "Mary", "Peter", "Jane", "Tom", "Alice", "Henry", "Jack", "Maggie", "Sam" };
        int randomIndex = Random.Range(0, names.Length);
        return names[randomIndex];
        
    }
}

