Shader "Custom/PS1ToonSmoke"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {} 
        _TintColor ("Tint Color", Color) = (1,1,1,1)
        _JitterAmount ("Jitter Amount", Range(0, 0.01)) = 0.005
        _ColorRamp ("Color Ramp", 2D) = "white" {} // Used for toon shading
    }
    SubShader
    {
        Tags { "Queue"="Geometry" "RenderType"="Opaque" }
        Cull Off
        ZWrite On
        ZTest LEqual

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float jitter : TEXCOORD1;
            };

            sampler2D _MainTex;
            sampler2D _ColorRamp;
            float4 _TintColor;
            float _JitterAmount;

            // Fake low-precision jittering for PS1-like vertex warping
            float randomNoise(float2 uv)
            {
                return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453);
            }

            v2f vert (appdata_t v)
            {
                v2f o;
                float noise = randomNoise(v.uv);
                v.vertex.xz += (noise - 0.5) * _JitterAmount; // Simulate PS1 vertex jitter
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.jitter = noise;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float4 texColor = tex2D(_MainTex, i.uv) * _TintColor;
                
                // Use a color ramp to create a hard toon effect
                float brightness = dot(texColor.rgb, float3(0.299, 0.587, 0.114)); // Luminance
                texColor.rgb = tex2D(_ColorRamp, float2(brightness, 0.5)).rgb;

                return texColor;
            }
            ENDCG
        }
    }
}
