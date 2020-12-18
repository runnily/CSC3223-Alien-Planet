Shader "Unlit/Water"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _AnimationSpeed("Animation Speed", Range(0,3)) = 0.5
        _OffsetY("Offset Y", Range(0,10)) = 1
        _Color ("Color", Color) = (1,1,1,1)
        _Depth ("Depth Fade", Float) = 1.0
        _Fix ("Depth Distance", Float) = -0.09

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _AnimationSpeed;
            float _OffsetX;
            float _OffsetY;
            fixed4 _Color;
            float _Depth;
            float _Fix;

            v2f vert (appdata v)
            {
        
                v2f o;
                v.vertex.y += sin(_Time.y * _AnimationSpeed + v.vertex.x * _OffsetY);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;

            }
            ENDCG
        }
    }
}
