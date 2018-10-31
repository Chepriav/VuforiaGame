using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 300;  //Daño por disparo  
    public float timeBetweenBullets = 0.15f;    //Tiempo entre disparo
    public float range = 300f;                  //Distancia que la bala recorre.
    public float capsuleRadius = 100f;

    float timer;                        //Tiempo que pasa desde el ultimo disparo.
    Ray shootRay = new Ray();           //Variable que contiene el punto inicial y la direccion.
    RaycastHit shootHit;                // Resultado del objeto con el que colisiona la bala.
    int shootableMask;                  // Representa las capas o colliders de los objetos de las capas a colisionar
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    bool fireButton;

    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
        fireButton = false;
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(fireButton && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
            fireButton = false;
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }

    public void OnFire()
    {
        fireButton = true;
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;   //De donde sale la bala 
        shootRay.direction = transform.forward; //y hacia donde

        if (Physics.SphereCast(shootRay,capsuleRadius,out shootHit,range,shootableMask)) //Devuelve cierto o falso dependiendeo si toca o recorre todo el rango. 
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.Death();
            }
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }
}
