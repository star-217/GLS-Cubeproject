Shader "Custom/FogVertexExpHeightUniform"
{
	Properties
	{
		_FogDensity("FogDensity", float) = 1.0
		_FogDensityAttenuation("FogDensityAttenuation", float) = 1.0
		_TopColor("Top Color", Color) = (1,1,1,1)
		_BottomColor("Bottom Color", Color) = (1,1,1,1)
	}
		SubShader
	{
		Tags {
			//"RenderType" = "Opaque" 
			//
			"RenderType" = "Opaque"
			"IgnoreProjector" = "True"
			"Queue" = "Transparent"
			}
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			fixed4 _TopColor;
			fixed4 _BottomColor;
			struct appdata
			{
				float4 vertex : POSITION;
				float2 lightmapUv : TEXCOORD1;
				//
				half2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 lightmapUv : TEXCOORD1;
				float3 worldPosition : TEXCOORD2;
				float4 vertex : SV_POSITION;
				//柴田追加
				fixed4 color : COLOR;
				half2 uv : TEXCOORD0;
			};

			float _FogDensity;
			float _FogDensityAttenuation;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.lightmapUv = (v.lightmapUv * unity_LightmapST.xy) + unity_LightmapST.zw;
				o.worldPosition = mul(unity_ObjectToWorld, v.vertex);
				return o;
			}

			//柴田変更
			float calcFogHeightExp(float3 objectPosition, float3 cameraPosition, float densityY0, float densityAttenuation)
			{
				float3 camToObj = cameraPosition - objectPosition;
				float l = length(camToObj);
				float ret;
				float tmp = l * densityY0 * exp(-densityAttenuation * objectPosition.y);
				if (camToObj.y == 1000.0) // 単純な均一フォグ
				{
					ret = exp(-tmp);
				}
				else
				{
					float kvy = densityAttenuation * camToObj.y;
					ret = exp(tmp / kvy * (exp(-kvy) - 1.0));
				}
				return ret;
			}

			fixed4 frag(v2f i) : COLOR{
					float fog = calcFogHeightExp(i.worldPosition, _WorldSpaceCameraPos, _FogDensity, _FogDensityAttenuation);
					i.color = lerp(_BottomColor, _TopColor, fog);
					return i.color;
		}

		ENDCG
	}
	}
}