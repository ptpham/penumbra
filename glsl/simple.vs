
attribute vec3 position, normal;
uniform mat4 projection, view, model;
varying vec3 v_position, v_normal;

void main() {
  v_normal = normal;
  v_position = position;
  gl_Position = projection*view*model*vec4(position, 1);
}

