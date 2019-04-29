Shader "Custom/EdgeShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _SensitivityDepth ("Sensitivity Depth", Range(0,5)) = 3.75
        _SensitivityNormals ("Sensitivity Normals", Range(0,5)) = 0.82
        _SampleDistance ("Sample Distance", Range(0,2)) = 1
        _Falloff ("Falloff", Range(0, 100)) = 10
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows finalcolor:edgecolor

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _CameraDepthNormalsTexture;

        struct Input
        {
            float2 uv_MainTex;
            float4 screenPos;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        uniform half _SensitivityDepth;
        uniform half _SensitivityNormals;
        uniform half _SampleDistance;
        uniform half _Falloff;

        inline half CheckSame(half2 centerNormal, float centerDepth, half4 sample)
        {
            // Difference in normals.
            half2 diff = abs(centerNormal - sample.xy) * _SensitivityNormals;
            int isSameNormal = (diff.x + diff.y) * _SensitivityNormals < 0.1;
            float sampleDepth = DecodeFloatRG(sample.zw);
            float zdiff = abs(centerDepth - sampleDepth);
            int isSameDepth = zdiff * _SensitivityDepth < 0.09 * centerDepth;
            
            return isSameNormal * isSameDepth ? 1.0 : 0.0;
        }

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        //UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        //UNITY_INSTANCING_BUFFER_END(Props)

        void edgecolor (Input IN, SurfaceOutputStandard o, inout fixed4 color)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
