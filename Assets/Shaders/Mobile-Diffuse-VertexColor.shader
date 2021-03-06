// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

// Simplified Diffuse shader. Differences from regular Diffuse one:
// - no Main Color
// - fully supports only 1 directional light. Other lights can affect it, but it will be per-vertex/SH.

Shader "Custom/Diffuse Vertex Color" {
Properties {
}
SubShader {
    Tags { "RenderType"="Opaque" }
    LOD 150

CGPROGRAM
#pragma surface surf Lambert noforwardadd


struct Input {
    float4 vertexColor : COLOR;
};

void surf (Input IN, inout SurfaceOutput o) {
    o.Albedo = IN.vertexColor.rgb;
    o.Alpha = IN.vertexColor.a;
}
ENDCG
}

Fallback "Mobile/VertexLit"
}
