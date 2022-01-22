using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
	public Transform player;
	public float range = 15;
	public int enemyLayer;
	public Texture2D aim;
	public float aimSize = 50;
	public Transform camera;
	private GameObject currentTarget;
	private Collider[] colls = new Collider[0];
	public float rotY;
	public float rotX;



	void PlayerRotate()
	{
		if (currentTarget)
		{
			
			//rotY = Mathf.Clamp(rotY, -30f, 30f);
			//rotX = Mathf.Clamp(rotX, -90f, 90f);
			//camera.transform.Rotate(-rotY, 0, 0);
			//camera.transform.Rotate(0, rotX, 0);
			Vector3 lookPos = currentTarget.transform.position - player.position;
			lookPos.y = 0;
			Quaternion rotation = Quaternion.LookRotation(lookPos);
			player.rotation = Quaternion.Lerp(player.rotation, rotation, 10 * Time.deltaTime);
		}
	}

	void OnGUI()
	{
		if (currentTarget)
		{
			Vector2 tmp = new Vector2(Camera.main.WorldToScreenPoint(currentTarget.transform.position).x,
									  Screen.height - Camera.main.WorldToScreenPoint(currentTarget.transform.position).y);

			Vector2 offset = new Vector2(-aimSize / 2, -aimSize / 2);
			GUI.DrawTexture(new Rect(tmp.x + offset.x, tmp.y + offset.y, aimSize, aimSize), aim);
		}
	}

	void Update()
	{
		if (Input.GetMouseButton(1))
		{
			rotY = Mathf.Clamp(rotY, -30f, 30f);
			rotX = Mathf.Clamp(rotX, -90f, 90f);
			GetTarget();
			//camera.transform.Rotate(-rotY, 0, 0);
			//camera.transform.Rotate(0, rotX, 0);
			if (colls.Length > 1)
			{
				if (Input.GetKeyDown(KeyCode.LeftShift)) // выбор другой ближайшей цели, исключая текущую - левый шифт
				{
					NearTarget();
				}
			}

			if (colls.Length == 0)
			{
				currentTarget = null;
			}
			else
			{
				float curDist = Vector3.Distance(player.position, currentTarget.transform.position);
				if (curDist > range) currentTarget = null;
			}
		}
		else
		{
			currentTarget = null;
		}
		PlayerRotate();
	}

	void NearTarget()
	{
		if (colls.Length > 0)
		{
			Collider currentCollider = null;
			float dist = Mathf.Infinity;

			foreach (Collider coll in colls)
			{
				float currentDist = Vector3.Distance(player.position, coll.transform.position);

				if (currentTarget)
				{
					if (currentDist < dist && currentTarget != coll.gameObject)
					{
						currentCollider = coll;
						dist = currentDist;
					}
				}
				else
				{
					if (currentDist < dist)
					{
						currentCollider = coll;
						dist = currentDist;
					}
				}
			}

			currentTarget = currentCollider.gameObject;
		}
	}

	void GetTarget()
	{
		colls = new Collider[0];
		colls = Physics.OverlapSphere(player.position, range, 1 << enemyLayer);

		if (currentTarget) return;

		NearTarget();
	}

}
