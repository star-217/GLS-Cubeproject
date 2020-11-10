﻿using System.Collections;
using UnityEngine;
using Es.InkPainter;


namespace Es.InkPainter.Sample
{
	[RequireComponent(typeof(Collider), typeof(MeshRenderer))]
	public class CollisionPainter : MonoBehaviour
	{
		[SerializeField]
		private Brush brush = null;

		[SerializeField]
		private int wait = 3;

		private int waitCount;

		[SerializeField] private float effect_length;

		[SerializeField]
		private ParticleSystem effect;

		[SerializeField]
		private float player_speed;

		[SerializeField] float ink_max = 200;
		private Color default_color;
		
		public int count = 15;// 塗りを行う回数
		public float intervalSecond = 0.05f;// 塗りを行う隔(秒)
		public float addScale = 0.01f; //インクが広がる強さ
		public float attenuation = 0.85f;// インクが広がる強さの減衰率
		

		Rigidbody rigidbody;


		public float Ink_max
        {
            get { return ink_max; }
			set { ink_max = value; }
        }
		
		public void Awake()
		{
			GetComponent<MeshRenderer>().material.color = brush.Color;
			rigidbody =  GetComponent<Rigidbody>();
			default_color = brush.Color;
		}

		public void FixedUpdate()
		{
			++waitCount;
		}

		public void OnCollisionStay(Collision collision)
		{

		    

			if(waitCount < wait)
				return;
			waitCount = 0;
			var dir = rigidbody.velocity.normalized * -1;

			foreach (var p in collision.contacts)
			{
				var canvas = p.otherCollider.GetComponent<InkCanvas>();

				if (canvas != null)
				{
					ink_max -= 1;
					//canvas.Paint(brush, p.point);
					if (ink_max > 0)
					{
						brush.Color = default_color;
						if (rigidbody.velocity.sqrMagnitude > player_speed * player_speed)
							Instantiate(effect, p.point + dir * effect_length, Quaternion.identity);


						StartCoroutine(HogePaint(canvas, p.point));
					}
                    else
                    {
						brush.Color = new Color(0, 0, 1, 0.01f);
						StartCoroutine(HogePaint(canvas, p.point));
					}
				}


				

			}
			//Instantiate(effect, collision.transform.position, Quaternion.identity);
		}

		private IEnumerator HogePaint(InkCanvas canvas, Vector3 contactPoint)
		{
			var brush = new Brush(this.brush.BrushTexture, this.brush.Scale, this.brush.Color);
			float addScale = this.addScale;
			for (int i = 0; i < count; i++)
			{
				brush.RotateAngle = UnityEngine.Random.Range(0.0f, 360.0f);
				brush.Scale += addScale;
				canvas.Paint(brush, contactPoint);
				yield return new WaitForSeconds(intervalSecond);
				addScale *= attenuation;
				
			}
		}

		

      
    }
}