Shader "Unlit/zBrushGround"
{
    Properties
    {
        _Tex1 ("Tex 1", 2D) = "white" {}
        _Tex2 ("Tex 2", 2D) = "white" {}
        _MaskTex ("Mask", 2D) = "white" {}
        _MaskFilter ("Mask Filter", Float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MaskTex, _Tex1, _Tex2;
            float _MaskFilter;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float mask = tex2D(_MaskTex, i.uv).r;
                float4 col1 = tex2D(_Tex1, i.uv);
                float4 col2 = tex2D(_Tex2, i.uv);
                float4 albedo = lerp(col1, col2, mask + _MaskFilter);
                return albedo;
            }
            ENDCG
        }
    }
    Fallback "Diffuse"
}
