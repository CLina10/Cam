using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float damage = 2f;
    public float range = 10f;

    public GameObject player;
    public ParticleSystem Flashlight;

    void Update()
    {
        //Debug.DrawRay(player.transform.position + Vector3.up * 0.2f, player.transform.forward, Color.red, 3f);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Flashlight.Play();
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position + Vector3.up * 0.2f, player.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            
            EnemyBehaviour target = hit.transform.GetComponent<EnemyBehaviour>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
