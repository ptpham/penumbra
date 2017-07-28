
precision mediump float;

varying vec3 v_position, v_normal;

uniform vec3 start0, end0;
uniform float radius0;
uniform vec3 start1, end1;
uniform float radius1;
uniform vec3 start2, end2;
uniform float radius2;
uniform vec3 start3, end3;
uniform float radius3;
uniform int count;

#pragma glslify: occlude_pill = require(./occlude_pill.glsl)

void main() {
  vec3 normal = normalize(v_normal);

  float occlusion0 = 0.0, occlusion1 = 0.0, occlusion2 = 0.0, occlusion3 = 0.0;

  if (count > 0) {
    occlusion0 = occlude_pill(start0, end0, radius0, v_position, normal);
  }

  if (count > 1) {
    occlusion1 = occlude_pill(start1, end1, radius1, v_position, normal);
  }

  if (count > 2) {
    occlusion2 = occlude_pill(start2, end2, radius2, v_position, normal);
  }

  if (count > 3) {
    occlusion3 = occlude_pill(start3, end3, radius3, v_position, normal);
  }

  float value = 1.0 - max(max(occlusion0, occlusion1), max(occlusion2, occlusion3));
  gl_FragColor = vec4(value, value, value, 1.0);
}

