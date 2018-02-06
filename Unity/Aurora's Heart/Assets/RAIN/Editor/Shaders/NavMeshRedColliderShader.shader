Shader "RAIN/NavMeshRedColliderShader"
{
	Properties
	{
		_colorFail ("_colorFail", Color) = (0.7, 0.1, 0.1, 1)
	}
    SubShader
    {
    	Tags { "RenderType" = "Opaque" }
		Offset -1, -1

		CGPROGRAM
		#pragma surface surf Lambert
		
		float4 _colorFail;
		
		struct Input
		{
			float4 color : COLOR;
		};
		
		void surf(Input IN, inout SurfaceOutput o)
		{
			o.Albedo = _colorFail;
		}
		
		ENDCG
    }
    FallBack "Diffuse"
}
