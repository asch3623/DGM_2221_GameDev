using System.Collections;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Collider))]
public class TransparencyFade : MonoBehaviour
{
    public bool complete;
    private float seconds = .5f;
    private float transparency;
    public UnityEvent onComplete;
    private float i = 0.7f;
    public Color mColor;
    public MeshRenderer mesh;
    private EnemyBehaviour enemy;
    private Collider col;
    private int waitTime = 10;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        enemy = GetComponent<EnemyBehaviour>();
            mColor = mesh.material.color;
        complete = false;
        col = GetComponent<Collider>();
        


    }
    
    
    
    public void StartFade()
    {
        if (complete == false)
        {
            StartCoroutine(FadeObj());
        }
    }
    public IEnumerator FadeObj()
    {
        transparency = 1f;
        col.enabled = false;

        while (transparency >= 0f)
        {
            transparency -= i * Time.deltaTime;
            mesh.material.color = new Color(mColor.r, mColor.g, mColor.b, transparency);
            yield return null;
        }

        if (transparency <= 0f)
        {
            complete = true;
            onComplete.Invoke();
        }

    }
    

    public void DestroyAfterFade()
    {
        Destroy(gameObject);
    }
}
