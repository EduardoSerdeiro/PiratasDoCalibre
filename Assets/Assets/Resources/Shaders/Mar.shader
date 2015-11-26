Shader "Custom/Mar" {
Properties {
      _Color ("Color", Color) = (1,1,1,1)
	  _MainTex ("Texture", 2D) = "white" {}
      _Cube ("Cubemap", CUBE) = "" {}
	  _Frequency ("Frequency", Range(0,5)) = 2
		_Amplitude ("Amplitude", Float) = 2
		_Refl ("Reflect", Range(0,2)) = 0.8
    }
    SubShader {
     
	  CULL OFF
      CGPROGRAM
      #pragma surface surf Lambert vertex:vert

	  sampler2D _MainTex;
		samplerCUBE _Cube;

		fixed4 _Color;
		float _Frequency;
		float _Amplitude;
		float _Refl;

      struct Input {
          float2 uv_MainTex;
          float3 worldRefl;
      };
		

	   void vert (inout appdata_full v) {
          v.vertex.y  = _Amplitude * sin(_Time.y * _Frequency - ((v.vertex.x) * (-v.vertex.z)));
      }

      void surf (Input IN, inout SurfaceOutput o) {
		    fixed4 color = tex2D (_MainTex, IN.uv_MainTex) * (_Color * 0.7);
			o.Albedo = color.rgb;
			o.Alpha = color.a * _Color.a;
            o.Emission = texCUBE (_Cube, IN.worldRefl).rgb * (_Refl);
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }