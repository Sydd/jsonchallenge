using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPool : MonoBehaviour
{
    public GameObject textPrefab;

    public List<GameObject> textList;

    static TextPool Instance;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < transform.childCount; i++)
        {
            textList.Add(transform.GetChild(i).gameObject);
        } 
    }

    public static GameObject GetOneText()
    {
        if (Instance.transform.childCount > 0)
        {
            Instance.transform.GetChild(0).gameObject.SetActive(true);

            return Instance.transform.GetChild(0).gameObject;
        }

        return Instantiate(Instance.textPrefab, Instance.transform);
    }
}
