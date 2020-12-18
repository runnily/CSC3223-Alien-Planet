Shader "Unlit/Water1"
{
    Properties
    {
        // color of the water
        _Color("Color", Color) = (1, 1, 1, 1)
        // color of the edge effect
        _EdgeColor("Edge Color", Color) = (1, 1, 1, 1)
        // width of the edge effect
        _DepthFactor("Depth Factor", float) = 1.0
        _DepthRampTex("Ramp Texture", 2D) = "white" {}
        _WaveSpeed("Wave Speed", float) = 1.0
        _WaveAmp("Wave Amp", float) = 1.0
        _NoiseTex("Noise Texture", 2D) = "white" 
    }

    SubShader
        {
            Pass
            {

                CGPROGRAM
                // required to use ComputeScreenPos()
                #include "UnityCG.cginc"

                #pragma vertex vert
                #pragma fragment frag
                

                struct appdata
                {
                float4 vertex : POSITION;
                float4 uv : TEXCOORD0;
                };

                struct vtf
                {
                float4 pos : SV_POSITION;
                float4 screenPos : TEXCOORD1;
                };

                sampler2D _CameraDepthTexture;
                float _DepthFactor;
                float4 _Color;
                float4 _EdgeColor;
                sampler2D _DepthRampTex;
                float _WaveSpeed;
                float _WaveAmp;
                sampler2D _NoiseTex;

                vtf vert(appdata v)
                {
                    vtf o;
                    // convert to camera clip space
                    o.pos = UnityObjectToClipPos(v.vertex);

                    // apply wave animation
                    float noiseSample = tex2Dlod(_NoiseTex, float4(v.uv.xy, 0, 0));
                    o.pos.y += sin(_Time*_WaveSpeed*noiseSample)*_WaveAmp;
                    //v.vertex.y += sin(_Time.y * _WaveSpeed+ v.vertex.x)*_WaveAmp;
                    o.pos.x += cos(_Time*_WaveSpeed*noiseSample)*_WaveAmp;
                    
                    // compute depth (screenPos is a float4)
                    o.screenPos = ComputeScreenPos(o.pos);

                    return o;
                }

                fixed4 frag(vtf i) : COLOR
                {
                    float4 depthSample = SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, i.screenPos);
                    float depth = LinearEyeDepth(depthSample).r;

                    // apply the DepthFactor to be able to tune at what depth values
                    // the foam line actually starts
                    float foamLine = 1 - saturate(_DepthFactor * (depth - i.screenPos.w));

                    // multiply the edge color by the foam factor to get the edge,
                    // then add that to the color of the water
                    float4 foamRamp = float4(tex2D(_DepthRampTex, float2(foamLine, 0.5)).rgb, 1.0);
                    fixed4 col = _Color + foamLine * _EdgeColor;
                    return col;
                }

        ENDCG
        }
    }
}