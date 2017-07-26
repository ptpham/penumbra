
attribute vec3 position, normal;
uniform mat4 projection, view, model;
varying vec3 v_position, v_normal;

void main() {
  vec4 world_position = model*vec4(position, 1);
  gl_Position = projection*view*world_position;
  v_position = world_position.xyz;
  v_normal = normal;
}

