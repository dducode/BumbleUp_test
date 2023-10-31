Shader "Custom/SimpleLit" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
	}
	SubShader {
		Tags {
			"RenderType" = "Opaque"
			"LightMode" = "ForwardBase"
		}
		LOD 100

		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityStandardBRDF.cginc"



			struct vertData {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};



			struct v2f {
				float4 vertex : SV_POSITION;
				float3 normal : TEXCOORD0;
			};


			float4 _Color;

			
			v2f vert (const vertData v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.normal = UnityObjectToWorldNormal(v.normal);
				return o;
			}


			float4 frag (const v2f i) : SV_Target {
				const float3 lightDirection = _WorldSpaceLightPos0.xyz;
				const float3 lightColor = _LightColor0.xyz;
				const float3 color = _Color.xyz;
				const float3 diffuse = dot(lightDirection, i.normal) * lightColor * color;
				return float4(diffuse, 1);
			}
			ENDCG
		}
	}
}