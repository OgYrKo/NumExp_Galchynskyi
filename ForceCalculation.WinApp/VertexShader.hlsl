cbuffer ConstantBuffer : register(b0)
{
    matrix worldViewProj;
}

struct VS_INPUT
{
    float3 Position : POSITION;
    float4 Color : COLOR;
};

struct PS_INPUT
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR;
};

PS_INPUT VSMain(VS_INPUT input)
{
    PS_INPUT output;
    output.Position = mul(float4(input.Position, 1.0f), worldViewProj);
    output.Color = input.Color;
    return output;
}
