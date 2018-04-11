using UnityEngine;

using System.Collections;

public class playerShoot: MonoBehaviour {

	public int gunDamage = 1;                                           

	public float fireRate = .25f;                                       

	public float weaponRange = 50f;                                     

	public float hitForce = 100f;

	public Transform gunEnd;

	public ParticleEmitter part;



	private Camera fpsCam;

	private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

	private AudioSource gunAudio;

	private LineRenderer laserLine;

	private float nextFire; 



	void Start () 
	{
		laserLine = GetComponent<LineRenderer>();
		gunAudio = GetComponent<AudioSource>();
		fpsCam = GetComponentInParent<Camera> ();
	}

	void Update () 
	{

		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) 

		{

			nextFire = Time.time + fireRate;
			StartCoroutine(ShotEffect());
			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (.5f, .5f, 0));
			RaycastHit hit;
			laserLine.SetPosition(0, gunEnd.position);
			if (Physics.Raycast(rayOrigin,fpsCam.transform.forward, out hit, weaponRange))
			{
				laserLine.SetPosition (1, hit.point);
			}
			else

			{
				laserLine.SetPosition(1, fpsCam.transform.forward * weaponRange);
			}

		}




	}




	private IEnumerator ShotEffect()

	{

		gunAudio.Play ();
		laserLine.enabled = true;
		yield return shotDuration;

		laserLine.enabled = false;
	}


}