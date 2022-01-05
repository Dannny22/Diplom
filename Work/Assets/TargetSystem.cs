using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
	public Transform player;
	public float range = 15;
	public int enemyLayer = 8;

	public Texture2D aim;
	public float aimSize = 50;

	private GameObject currentTarget;
	private Collider[] colls = new Collider[0];

	//void RandomTarget()
	//{
	//	GameObject[] tmp = new GameObject[0];

	//	int x = 0;
	//	foreach (Collider element in colls)
	//	{
	//		if (currentTarget != element.gameObject) x++;
	//	}
	//	GameObject[] pureArray = new GameObject[x];
	//	x = 0;
	//	foreach (Collider element in colls)
	//	{
	//		if (currentTarget != element.gameObject)
	//		{
	//			pureArray[x] = element.gameObject;
	//			x++;
	//		}
	//	}
	//	tmp = new GameObject[pureArray.Length];
	//	for (int i = 0; i < tmp.Length; i++)
	//	{
	//		tmp[i] = pureArray[i];
	//	}

	//	currentTarget = tmp[Random.Range(0, tmp.Length)];
	//}

	void PlayerRotate()
	{
		if (currentTarget)
		{
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
			GetTarget();

			if (colls.Length > 1)
			{
				if (Input.GetKeyDown(KeyCode.LeftShift)) // выбор другой ближайшей цели, исключая текущую - левый шифт
				{
					NearTarget();
				}
				//else if (Input.GetKeyDown(KeyCode.LeftControl)) // выбор случайной цели, исключая текущую - левый контрол
				//{
				//	RandomTarget();
				//}
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
