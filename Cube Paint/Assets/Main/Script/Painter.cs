using UnityEngine;
using System.Collections;

namespace Es.InkPainter.Sample
{
	[RequireComponent(typeof(Collider), typeof(MeshRenderer))]
	public class Painter : MonoBehaviour
	{
		[SerializeField]
		private Brush brush = null;

		[SerializeField]
		private int wait = 3;

		private Color paintColor;

		private int waitCount;


		public ParticleSystem[] effect;
		private SetMaterial setMaterial;
		[SerializeField] private GameObject subPlayer;
		private int effectNumber;


		private Rigidbody rigidbody;

		public int count = 15;// 塗りを行う回数
		public float intervalSecond = 0.05f;// 塗りを行う隔(秒)
		public float addScale = 0.01f; //インクが広がる強さ
		public float attenuation = 0.85f;// インクが広がる強さの減衰率

		public Color SubPaintColor
		{
			set { paintColor = value; }
			get { return paintColor; }
		}

		public void Awake()
		{
			//GetComponent<MeshRenderer>().material.color = brush.Color;
			rigidbody = GetComponent<Rigidbody>();
			if (GetComponent<SetMaterial>() != null)
			{
				setMaterial = subPlayer.GetComponent<SetMaterial>();
				effectNumber = setMaterial.MaterialsNum;
			}
			else
			{
				effectNumber = 0;
			}
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
					canvas.Paint(brush,p.point);

				StartCoroutine(HogePaint(canvas, p.point));

				if(rigidbody.velocity.magnitude > 20.0f)
					Instantiate(effect[effectNumber], p.point + dir * 0.1f, Quaternion.identity);

			}
		}

		private IEnumerator HogePaint(InkCanvas canvas, Vector3 contactPoint)
		{
			if (canvas == null)
				yield break;

			var brush = new Brush(this.brush.BrushTexture, this.brush.Scale, paintColor);


			//brush.Color = paintColor;

			float addScale = this.addScale;

			for (int i = 0; i < count; i++)
			{
				brush.RotateAngle = UnityEngine.Random.Range(0.0f, 360.0f);
				//brush.Color = new Color(UnityEngine.Random.Range(0.0f,1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f));

				brush.Scale += addScale;
				//	brush.Color -= new Color(0, 0, 0, 10);
				canvas.Paint(brush, contactPoint);
				yield return new WaitForSeconds(intervalSecond);
				addScale *= attenuation;
				//brush.Color = default_color;

				//brush.Color = Color.HSVToRGB(0, 0, 0);
			}
		}
	}
}