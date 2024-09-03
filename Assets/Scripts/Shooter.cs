using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [Header("General")]
    [SerializeField] GameObject projecttilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projecttileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;

    [HideInInspector] public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

     void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();  
    }

    // Start is called before the first frame update
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

     void Fire()
    {
        if (isFiring && firingCoroutine==null)
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuosly()
    {
        while (true) {
            GameObject instance = Instantiate(projecttilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb!=null)
            {
                rb.velocity = transform.up * 5f;
            }
            if (useAI)
            {
                rb.velocity = -transform.up * projectileSpeed;
            }

            Destroy(instance, projecttileLifetime);

            float timeToNextProjecttile = Random.Range(baseFiringRate - minimumFiringRate, baseFiringRate + firingRateVariance);

            timeToNextProjecttile = Mathf.Clamp(timeToNextProjecttile,minimumFiringRate, float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjecttile);
        }
    }
}
