#include <metal_stdlib>
using namespace metal;

struct v2f
{
    float4 position [[position]];
    float3 normal;
    half3 color;
    float2 texcoord;
};

struct VertexData
{
    float3 position;
    float3 normal;
    float2 texcoord;
};

struct InstanceData
{
    float4x4 instanceTransform;
    float3x3 instanceNormalTransform;
    float4 instanceColor;
};

struct CameraData
{
    float4x4 perspectiveTransform;
    float4x4 worldTransform;
    float3x3 worldNormalTransform;
};

v2f vertex vertexMain( device const VertexData* vertexData [[buffer(0)]],
                      device const InstanceData* instanceData [[buffer(1)]],
                      device const CameraData& cameraData [[buffer(2)]],
                      uint vertexId [[vertex_id]],
                      uint instanceId [[instance_id]] )
{
    v2f o;

    const device VertexData& vd = vertexData[ vertexId ];
    float4 pos = float4( vd.position, 1.0 );
    pos = instanceData[ instanceId ].instanceTransform * pos;
    pos = cameraData.perspectiveTransform * cameraData.worldTransform * pos;
    o.position = pos;

    float3 normal = instanceData[ instanceId ].instanceNormalTransform * vd.normal;
    normal = cameraData.worldNormalTransform * normal;
    o.normal = normal;

    o.texcoord = vd.texcoord.xy;

    o.color = half3( instanceData[ instanceId ].instanceColor.rgb );
    return o;
}

half4 fragment fragmentMain( v2f in [[stage_in]], texture2d< half, access::sample > tex [[texture(0)]] )
{
    constexpr sampler s( address::repeat, filter::linear );
    half3 texel = tex.sample( s, in.texcoord ).rgb;

    // Assume light coming from (front-top-right)
    float3 l = normalize(float3( 1.0, 1.0, 0.8 ));
    float3 n = normalize( in.normal );

    half ndotl = half( saturate( dot( n, l ) ) );

    half3 illum = (in.color * texel * 0.1) + (in.color * texel * ndotl);
    return half4( illum, 1.0 );
}
