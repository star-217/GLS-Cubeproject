using UnityEngine;
using System.Collections;

namespace Es.InkPainter.Sample
{
	[RequireComponent(typeof(Collider), typeof(MeshRenderer))]
	public class PlayerPainter: MonoBehaviour
	{
		[SerializeField]
		private Brush brush = null;

		[SerializeField]
		private int wait = 3;

		private int waitCount;

		//[SerializeField]
		//private ParticleSystem effect;

		private Rigidbody rigidbody;

		public int count = 15;// 塗りを行う回数
		public float intervalSecond = 0.05f;// 塗りを行う隔(秒)
		public float addScale = 0.01f; //インクが広がる強さ
		public float attenuation = 0.85f;// インクが広がる強さの減衰率

		[SerializeField] private InkCanvas canvas = null;

		public Color GetColor
        {
            get { return brush.Color; }
		}


		public void Awake()
		{
			//GetComponent<MeshRenderer>().material.color = brush.Color;
			rigidbody = GetComponent<Rigidbody>();
		}

		public void FixedUpdate()
		{
			++waitCount;
		}

		public void OnCollisionStay(Collision collision)
		{
			if (!collision.gameObject.CompareTag("Floor"))
				return;

			if(waitCount < wait)
				return;

			waitCount = 0;

			foreach (var p in collision.contacts)
			{
				StartCoroutine(HogePaint(canvas, p.point));
			}
		}

		private IEnumerator HogePaint(InkCanvas canvas, Vector3 contactPoint)
		{
			var brush = new Brush(this.brush.BrushTexture, this.brush.Scale, this.brush.Color);

			float addScale = this.addScale;

			for (int i = 0; i < count; ++i)
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