using System.Collections;
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

		public int count = 15;// 塗りを行う回数
		public float intervalSecond = 0.05f;// 塗りを行う隔(秒)
		public float addScale = 0.01f; //インクが広がる強さ
		public float attenuation = 0.85f;// インクが広がる強さの減衰率

		Rigidbody rigidbody;


		Vector3[] vector3;
		public void Awake()
		{
			GetComponent<MeshRenderer>().material.color = brush.Color;
			rigidbody =  GetComponent<Rigidbody>();
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
					//canvas.Paint(brush, p.point);
					if(rigidbody.velocity.sqrMagnitude > player_speed* player_speed) 
					Instantiate(effect, p.point + dir * effect_length, Quaternion.identity);


					StartCoroutine(HogePaint(canvas, p.point));
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

        private void Update()
        {
			//if(brush.Scale >= 0.15f)
   //         {
			//	brush.Scale = 0;

			//}

		}
    }
}