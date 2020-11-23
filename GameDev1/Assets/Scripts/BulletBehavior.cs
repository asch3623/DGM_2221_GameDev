using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class BulletBehavior : MonoBehaviour
{
    private Rigidbody rBody;
    public float bulletForce;
    public float lifeTime;
    public UnityEvent enemyHit;

    private IEnumerator Start()
    {
        rBody = GetComponent<Rigidbody>();
        
        rBody.AddRelativeForce(Vector3.forward * bulletForce);
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        
            print("isHIt");
            if (other.gameObject.CompareTag("Enemy"))
            {
                enemyHit?.Invoke();
                StopAllCoroutines();
                Destroy(gameObject);
            }
        
    }
}