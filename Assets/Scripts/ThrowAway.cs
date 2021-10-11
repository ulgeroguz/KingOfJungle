using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAway : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius = 5.0F;
    public float power = 10.0F;
    public float upForce;
    public GameManager gm;
    

    Vector3 explosionPos;
   
    public void Explode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, upForce, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
  

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("Throw", 2);
            Invoke("Panel", 3);
        }
    }


    private void Throw()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, upForce, ForceMode.Impulse);
        }
    }

    private void Panel()
    {
        gm.Finish();
    }
}
