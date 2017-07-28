
precision mediump float;

varying vec3 v_position, v_normal;

uniform vec3 center;
uniform float radius;

#pragma glslify: psahe = require('./psahe.glsl')

void main() {
  vec3 normal = normalize(v_normal);
  vec3 dir = center - v_position;
  float ld = length(dir);
  dir /= ld;

  float gamma = asin(min(radius/ld, 1.0));
  float ndotd = dot(normal, dir);
  float factor = psahe(ndotd, gamma);
  float value = 1.0 - factor;

  gl_FragColor = vec4(value, value, value, 1.0);
}

