using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RecursiveFunc(5);
    }
    
    // 재귀함수 
    void RecursiveFunc(int count)
    {
        if (count <= 0)
        {
            Debug.Log("카운트 종료");
            return;
        }
        
        Debug.Log($"카운트 {count}");
        RecursiveFunc(count - 1);
    }
}
