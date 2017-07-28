
precision mediump float;

varying vec3 v_position, v_normal;

uniform vec3 start, end;
uniform float radius;

#pragma glslify: occlude_pill = require(./occlude_pill.glsl)

void main() {
  vec3 normal = normalize(v_normal);
  float occlusion = occlude_pill(start, end, radius, v_position, normal);
  float value = 1.0 - occlusion;
  gl_FragColor = vec4(value, value, value, 1.0);
}

