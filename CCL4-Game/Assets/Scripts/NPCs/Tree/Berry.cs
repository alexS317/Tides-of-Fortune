using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    private float timer;

    public ParticleSystem berryParticles;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        AkSoundEngine.PostEvent("Play_TreeShoot", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            print("berry bad");
            Destroy(gameObject);
        }
    }

    private void OnCollisioTnEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Instantiate(berryParticles, transform.position, Quaternion.identity);

            DataStorage.Instance.DecreasePlayerHealth(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Instantiate(berryParticles, transform.position, Quaternion.identity);

            DataStorage.Instance.DecreasePlayerHealth(1);
            Destroy(gameObject);
        }
    }
}