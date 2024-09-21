using System.Collections;
using UnityEngine;
 
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
 
    public GameObject poop;
    public Transform objbox;
 
    void Start()
    {
        StartCoroutine(CreatepoopRoutine());
    }
 
    IEnumerator CreatepoopRoutine()
    {
        while (true)
        {
            CreatePoop();
            yield return new WaitForSeconds(0.3f);
        }
    }
 
    private void CreatePoop()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 5.0f));
        GameObject obj = Instantiate(poop, pos, Quaternion.identity);
        obj.transform.parent = objbox.transform;
    }
}