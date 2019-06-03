// Upgrade NOTE: replaced '_LightMatrix0' with 'unity_WorldToLight'

Shader "Custom/CustomToon"
{
	Properties
	{
		// Levels
		_SpecularColor ("Specular colour", Color) = (1,1,1,1)
		_Specular ("	Specular size", Range(-1, 1)) = 0.72
		_FadeSpecular ("	Specular blur", Range(-3, 1)) = 0
		
		_DiffuseColor ("Diffuse colour", Color) = (0.5,0.5,0.5,1) 
		_Diffuse ("	Diffuse size", Range(-1.1,1)) = 0.1
		_FadeDiffuse ("	Diffuse blur", float) = 0
		
		_ShadowColor ("Shadow colour", Color) = (0.25,0.25,0.25,1)
		_FadeShadow ("	Shadow blur", Range(0,1)) = 0
		
		_OutlineColor ("Outline colour", Color) = (0,0,0,0)
		_Outline ("	Outline size", Range(0,1)) = 0.3
		
		// Texture
		_MainTex ("Texture", 2D) = "white" {}
		_TexAlpha ("	Texture alpha", Range(0,1)) = 0
	}
	SubShader {
	Pass {
		Tags{ "LightMode" = "ForwardBase" }
		Cull Off
		// pass for ambient light and first light source
		
		CGPROGRAM
		// Used to recieve shadows.
		#include "Lighting.cginc"
		#include "AutoLight.cginc"
		#pragma multi_compile_fwdbase
		
		// Tells the cg to use a vertex-shader called vert
		#pragma vertex vert 
		// Tells the cg to use a fragment-shader called frag
		#pragma fragment frag
		
		
		// Variables.
		uniform float4 _DiffuseColor;
		uniform float4 _ShadowColor;
		uniform float4 _SpecularColor;
		
		uniform float _Diffuse;
		uniform float _FadeDiffuse;
		
		uniform float _Specular;
		uniform float _FadeSpecular;
		
		
		uniform float _Outline;
		uniform float _FadeShadow;
		
		uniform float4 _OutlineColor;
		uniform float _TexAlpha;
		
		// Uniform float4 _LightColor0;
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		
		// Spotlight.
		uniform float4x4 unity_WorldToLight;
		uniform sampler2D _LightTexture0;
		
		// Structures.
		struct vertexInput {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
			float4 texcoord : TEXCOORD0; 
		};
		
		struct vertexOutput {
			float4 pos : SV_POSITION;
			float3 normalDir : TEXCOORD1;
			float4 lightDir : TEXCOORD4;
			float3 viewDir : TEXCOORD3;
			float2 uv : TEXCOORD0;
			SHADOW_COORDS(2)
		};
		
		vertexOutput vert(vertexInput input){
			vertexOutput output;
			
			//normalDirection
			output.normalDir = normalize ( mul( float4( input.normal, 0.0 ), unity_WorldToObject).xyz );
			
			//World position
			float4 posWorld = mul(unity_ObjectToWorld, input.vertex);
			
			//view direction
			output.viewDir = normalize( _WorldSpaceCameraPos.xyz - posWorld.xyz ); //vector from object to the camera
			
			//light direction
			float3 fragmentToLightSource = ( _WorldSpaceCameraPos.xyz - posWorld.xyz);
			output.lightDir = float4(
			normalize( lerp(_WorldSpaceLightPos0.xyz , fragmentToLightSource, _WorldSpaceLightPos0.w) ),
			lerp(1.0 , 1.0/length(fragmentToLightSource), _WorldSpaceLightPos0.w)
			);
			
			//fragmentInput output;
			output.pos = UnityObjectToClipPos( input.vertex );  
			//UV-Map
			output.uv =input.texcoord;
			TRANSFER_SHADOW(output)
			return output;
		}
		
		float4 frag(vertexOutput input) : COLOR {
			float nDotL = saturate(dot(input.normalDir, input.lightDir.xyz)); 
			float shadow = SHADOW_ATTENUATION(input);
			
			//Diffuse threshold calculation
			float diffuseCutoff = saturate(( max(_Diffuse, nDotL) - _Diffuse) * (shadow - _FadeDiffuse) * 60 );
			
			//Specular threshold calculation
			float specularCutoff = saturate( max(_Specular, dot(reflect(-input.lightDir.xyz, input.normalDir), input.viewDir)) * shadow - _Specular) * (1-_FadeSpecular) * 100;
			
			//Calculate Outlines
			float outlineStrength = saturate( (dot(input.normalDir, input.viewDir ) - _Outline) * (1-_FadeShadow) * 200 );
			
			
			float3 ambientLight = (1-_TexAlpha) *(1-diffuseCutoff) * _ShadowColor.xyz + _TexAlpha * tex2D(_MainTex, input.uv);
			float3 diffuseReflection =  (1-specularCutoff) * _DiffuseColor.xyz * diffuseCutoff;
			float3 specularReflection = _SpecularColor.xyz * specularCutoff;
			
			float3 combinedLight = _OutlineColor * (1-outlineStrength) + (ambientLight + diffuseReflection) * outlineStrength + specularReflection;
			
			return float4(combinedLight, 1.0);
		}
		ENDCG
		}
	}
	
	Fallback "Diffuse"
}﻿