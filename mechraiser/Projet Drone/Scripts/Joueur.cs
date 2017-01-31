using UnityEngine;
using System.Collections;

public class Joueur : MonoBehaviour {

	int m_iNbVies ;
	int m_iNumeroJoueur ; //1, 2, 3 ou 4

	float m_fDeplacement ;

	// Use this for initialization
	void Start ()
	{
		m_iNbVies= 3 ;
		m_iNumeroJoueur= 1 ;
		m_fDeplacement= 5.0f ;
	}

	// Update is called once per frame
	void Update ()
	{
		deplacement();
		}

	/*** Destructeur ***/
	void tuerJoueur ()
	{
		Destroy(gameObject) ;
	}
		
	/*** Setter ***/
	void miseAJourNbVie (int NbVieSupp) 
	{
		m_iNbVies+= NbVieSupp ;

		if(0 >= m_iNbVies) // S'il n'a plus de vie, le joueur est détruit.
			tuerJoueur() ;

		Debug.Log("m_iNbVies  updated") ;
	}

	/*** Deplacement personnage ***/

	void deplacement()
	{
		if(Input.GetKey("joystick button 0"))
			transform.Translate(0, m_fDeplacement*Time.deltaTime, 0);

		if(    Mathf.Abs(Input.GetAxis("XBoxOne_LeftStickX")) > 0.3f 
			/*|| Mathf.Abs(Input.GetAxis("XBoxOne_LeftStickY")) > 0.3f*/)
			transform.Translate(m_fDeplacement*Input.GetAxis("XBoxOne_LeftStickX")*Time.deltaTime, 
								0, 					
								0) ;
//		if(Input.GetAxisRaw("XBoxOne_LeftStickY") > 0.3f || Input.GetAxisRaw("XBoxOne_LeftStickY") < -0.3f)
//			transform.Translate(0, 0, Input.GetAxis("XBoxOne_LeftStickY")*Time.deltaTime) ;
	}


	/*** Gestion des Collision ***/
	void OnCollisionEnter(Collision collision)
	{
		if("Projectile" == collision.collider.tag)
			miseAJourNbVie(-1);
	}

}
