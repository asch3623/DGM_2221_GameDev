using System.Collections;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(MeshRenderer))]
public class TransparencyFade : MonoBehaviour
{
    private bool complete;
    private float seconds = .5f;
    private float transparency;
    public UnityEvent onComplete;
    private float i = 0.7f;
    private Color mColor;
    private MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mColor = mesh.material.color;
        complete = false;
    }
    

    public void StartFade()
    {
        if (FadeObj() != null)
        {
            StartCoroutine(FadeObj());
        }

    }

    public IEnumerator FadeObj()
    {
        transparency = 1f;

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
}
