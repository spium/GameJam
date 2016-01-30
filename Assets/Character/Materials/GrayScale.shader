Shader "AppsMinistry/GrayScaleTransparentLit"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _EffectAmount ("GreyScale", Range (0, 1)) = 0.3
        _Ambient("MinimumLight",Color) = (0.3,0.3,0.3,1)
        _Color ("Tint", Color) = (1,1,1,1)
//        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
 
    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }
 
        Cull Off
        Lighting Off
        ZWrite Off
        Fog { Mode Off }
        Blend SrcAlpha OneMinusSrcAlpha
 
        Pass {
           Tags { "LightMode" = "Vertex" }//otherwise no light related values will be filled
           CGPROGRAM
           #pragma vertex vert
           #pragma fragment frag
           #include "UnityCG.cginc"
   
           sampler2D _MainTex;
           half4 _MainTex_ST;
           uniform float _EffectAmount;

           fixed4 _Ambient;
           fixed4 _Color;
           
            struct v2f
            {
                fixed4 position   : POSITION;
                fixed4 color      : COLOR;
                half2 uv_MainTex  : TEXCOORD0;                
            };
   
           v2f vert (appdata_base ab) {
               v2f o;
    
               o.position = mul(UNITY_MATRIX_MVP,ab.vertex);
               o.uv_MainTex = TRANSFORM_TEX(ab.texcoord.xy , _MainTex);
    
               // per vertex light calc
               fixed3 lightDirection;
               fixed attenuation;
               // add diffuse
               if(unity_LightPosition[0].w == 0.0)//directional light
               {
                  attenuation = 2;
                  lightDirection = normalize(mul(unity_LightPosition[0],UNITY_MATRIX_IT_MV).xyz);
               }
               else// point or spot light
               {
                  lightDirection = normalize(mul(unity_LightPosition[0],UNITY_MATRIX_IT_MV).xyz - ab.vertex.xyz);
                  attenuation = 1.0/(length(mul(unity_LightPosition[0],UNITY_MATRIX_IT_MV).xyz - ab.vertex.xyz)) * 0.5;
               }
               fixed3 normalDirction = normalize(ab.normal);
               fixed3 diffuseLight =  unity_LightColor[0].xyz * max(dot(normalDirction,lightDirection),0);

                o.color.xyz = diffuseLight * attenuation + _Ambient.xyz;
		        return o;
            }
   
        	fixed4 frag(v2f IN) : COLOR
            {
                half4 texcol = tex2D (_MainTex, IN.uv_MainTex);              
                texcol.rgb = lerp(texcol.rgb, dot(texcol.rgb, float3(0.3, 0.59, 0.11)), _EffectAmount);
                texcol = texcol * IN.color * _Color;
                return texcol;
            }
           
        	ENDCG
      	}

    }
    Fallback "Sprites/Default"
}