using UnityEngine;

using System.Collections;

public class sniperShoot: MonoBehaviour {

	public int gunDamage = 50;                                           

	public float fireRate = 1f;                                       

	public float weaponRange = 999f;                                     

	public float hitForce = 300f;

	public Transform gunEnd;

	public ParticleSystem part;

	private ParticleSystem Laser;



	private Camera fpsCam;

	private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

	private AudioSource gunAudio;

	private LineRenderer laserLine;

	private float nextFire; 

	public GameObject bulletEmitterPrefab;

	public Canvas scope;

	public bool isScoped;

	public int zoom;


	void Start () 
	{
		laserLine = GetComponent<LineRenderer>();
		gunAudio = GetComponent<AudioSource>();
		fpsCam = GetComponentInParent<Camera> ();
	}

	void Update () 
	{
		if (Input.GetButtonDown ("Fire2")) {
			isScoped = true;
			scope.enabled = true;
			Camera.main.fieldOfView = zoom;
		} else {

				isScoped = false;
				scope.enabled = false;
				Camera.main.fieldOfView = 60;
			
		}


		if (Input.GetButton ("Fire1") && Time.time > nextFire && isScoped) 
		{
			part.Play ();

			GameObject bullet = (GameObject) Instantiate (bulletEmitterPrefab, transform.position, transform.rotation);
			string name = bulletEmitterPrefab.name + "(Clone)";
			GameObject.Find (name).transform.parent = null;
			Laser = bullet.GetComponent<ParticleSystem> ();
			Laser.Play ();

			nextFire = Time.time + fireRate;
			StartCoroutine(ShotEffect());
			DestroyParticle (bullet);
			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (.5f, .5f, 0));
			RaycastHit hit;
			laserLine.SetPosition(0, gunEnd.position);
			if (Physics.Raycast(rayOrigin,fpsCam.transform.forward, out hit, weaponRange))
			{

				laserLine.SetPosition (1, hit.point);
				Debug.Log (hit.collider.gameObject.name);
				if(hit.collider.GetComponent<enemyHealthHandler>())
				{
					hit.collider.GetComponent<enemyHealthHandler> ().maxHP--;
				}
			}
			else

			{
				laserLine.SetPosition(1, fpsCam.transform.forward * weaponRange);
			}

		}




	}


	private IEnumerator DestroyParticle(GameObject bullet)
	{
		yield return shotDuration;
		Destroy (bullet);
	}


	private IEnumerator ShotEffect()

	{

		gunAudio.Play ();
		laserLine.enabled = true;
		yield return shotDuration;

		laserLine.enabled = false;
	}


}